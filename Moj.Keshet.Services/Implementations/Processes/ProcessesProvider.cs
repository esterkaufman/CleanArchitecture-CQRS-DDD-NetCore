using System.Collections.Generic;
using Moj.Keshet.Services.Interfaces;
using System.Threading.Tasks;
using Moj.Keshet.Domain.Models.Processes;
using System.Linq;
using Moj.Keshet.Shared.Enums;
using System;
using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Shared.Enums.DatabaseEnums;

namespace Moj.Keshet.Services.Implementations
{
    partial class Provider : IProcessesProvider
    {

        public async Task<ProcessFlatSearchResult[]> SearchAsync(ProcessSearchCriteria searchCriteria)
        {

            var list = await _processesRepository.Value.SearchAsync(searchCriteria, false);
            await FillContactDetailsInProcesses(list);
            return list;
        }

        private async Task  FillContactDetailsInProcesses(ProcessFlatSearchResult[] list)
        {
            var contacts = new List<BaseContactFlatSearchResult>();

            var ids = list.Select(x => x.AppraiserContactId).ToArray();
            if (ids.Any())
            {                
                contacts.AddRange(await GetBaseContactsByTypeAndId((byte)ContactTypesEnum.Appraiser,ids));
            }



            list.AsParallel().ForAll(p =>
            {                
                var contact = contacts.FirstOrDefault(c => c.ContactId == p.AppraiserContactId);
                if (contact != null)
                {
                    p.AppraiserContactName = contact.ContactName;
                    p.AppraiserContactPhone = contact.Telephones;
                }
            });
        }

        public async Task<Process> GetProcessById(long processID)
        {
            var prc = await _processesRepository.Value.GetProcessById(processID);
            await PrepareProcessContacts(prc);
            return prc;

        }


        private async Task PrepareProcessContacts(Domain.Models.Processes.Process process)
        {


            for (var i = 0; i < process.InterestContacts.Length; i++)
            {
                var contact = await GetContact(process.InterestContacts[i].ContactID);

                var contactRoleTypes = _contactsListItemsProvider.GetContactsListItems(LookupTableName.ProcessContactRoleTypes);

                var processContactRoleTypeIDs =
                    process.InterestContacts[i].ProcessContactRoleTypes.Select(x => x.Id).ToArray();
                contact.ProcessContactRoleTypes = contactRoleTypes
                    .Where(x => processContactRoleTypeIDs.Contains(x.Id)).ToArray();
                process.InterestContacts[i] = contact;
            }
        }
    }
}
