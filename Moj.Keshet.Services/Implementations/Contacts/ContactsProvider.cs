using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Services.Interfaces;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Implementations
{
    partial class Provider : IContactsProvider
    {

        public Task<Contact> GetContact(int id)
        {

            return _contactsRepository.Value.GetContact(id);
        }
        public Task<Contact> GetContactByIdNumber(string idNumber)
        {
            return _contactsRepository.Value.GetContactByIdNumber(idNumber);
        }
        public Task<Company[]> GetCompanies(int appealOrganization)
        {
            return _contactsRepository.Value.GetCompanies(appealOrganization);
        }

        public Task<Contact[]> GetContacts(ContactsSearchCriteria contactsSearchCriteria)
        {
            return _contactsRepository.Value.GetContacts(contactsSearchCriteria);
        }

        Task<BaseContactFlatSearchResult[]> GetBaseContactsByTypeAndId(byte contactTypeID, int[] contactIDs)
        {
            return _contactsRepository.Value.GetBaseContactsByTypeAndId(contactTypeID,contactIDs);
        }

        public Task<BaseContactFlatSearchResult[]> ContactsQuery (ContactsSearchCriteria contactsSearchCriteria)
        {
            return _contactsRepository.Value.ContactsQuery(contactsSearchCriteria);
        }
        public Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId)
        {
            return _contactsRepository.Value.GetAppealOrganizationOfWorkOrderContact(WorkOrderContactId);
        }


    }
}
