using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moj.Keshet.Services.DTOs.Contacts;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.Mapping;
using System.Linq;
using Newtonsoft.Json;
using Moj.Keshet.Domain.Models.ListItems;

namespace Moj.Keshet.Services.MediatR.Queries.Contacts
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, Contact>
    {
        private readonly IContactsProvider _contactsProvider;

        public GetContactHandler(IContactsProvider contactsProvider)
        {
            _contactsProvider = contactsProvider ?? throw new ArgumentNullException(nameof(contactsProvider));
        }

        public async Task<Contact> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {

            var contact = string.IsNullOrEmpty( request.IdentityNumber)? await _contactsProvider.GetContact(request.Id):
                await _contactsProvider.GetContactByIdNumber(request.IdentityNumber);

            if (contact == null)
            {
                return new Contact();
            }

            var contactDTO = contact.Map<Contact>();
            return contactDTO;
        }
    }
    public class GetCompaniesHandler:IRequestHandler<GetCompaniesQuery,Company[]>
    {
        private readonly IContactsProvider _contactsProvider;
        public GetCompaniesHandler(IContactsProvider contactsProvider)
        {
            _contactsProvider = contactsProvider ?? throw new ArgumentNullException(nameof(contactsProvider));
        }
        public async Task<Company[]> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var items = await this._contactsProvider.GetCompanies(request.AppealOrganization);

            var dtos = items.MapList<Company>();
            return dtos.ToArray() ;
               
        }
    }

    public class GetContactsHandler : IRequestHandler<GetContactsQuery, Contact[]>
    {
        private readonly IContactsProvider _contactsProvider;
        public GetContactsHandler(IContactsProvider contactsProvider)
        {
            _contactsProvider = contactsProvider ?? throw new ArgumentNullException(nameof(contactsProvider));
        }
        public async Task<Contact[]> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var query = request.ContactsSearchCriteria.Map<Domain.Models.Contacts.ContactsSearchCriteria>();
            var items = await this._contactsProvider.GetContacts(query);
            var dtos = items.MapList<Contact>();
            return dtos.ToArray();
            
        }
    }

    public class GetContactsFlatSearchHandler : IRequestHandler<GetFlatContactSearchQuery, BaseContactFlatSearchResult[]>
    {
        private readonly IContactsProvider _contactsProvider;
        public GetContactsFlatSearchHandler(IContactsProvider contactsProvider)
        {
            _contactsProvider = contactsProvider ?? throw new ArgumentNullException(nameof(contactsProvider));
        }
        public async Task<BaseContactFlatSearchResult[]> Handle(GetFlatContactSearchQuery request, CancellationToken cancellationToken)
        {
            var query = request.ContactsSearchCriteria.Map<Domain.Models.Contacts.ContactsSearchCriteria>();
            var searchCriteria = request.ContactsSearchCriteria;

            query.ContactIDs = !string.IsNullOrEmpty(searchCriteria.ContactIDsList) ? JsonConvert.DeserializeObject<int[]>(searchCriteria.ContactIDsList) : null;
            query.ContactSubTypeIDs = !string.IsNullOrEmpty(searchCriteria.ContactSubTypeIDsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.ContactSubTypeIDsList) : null;
            query.DistrictIDs = !string.IsNullOrEmpty(searchCriteria.DistrictIDsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.DistrictIDsList) : null;
            query.AppealOrganizationIDs = !string.IsNullOrEmpty(searchCriteria.AppealOrganizationIDsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.AppealOrganizationIDsList) : null;
            query.DistrictAppealOrganizationContactIDs = !string.IsNullOrEmpty(searchCriteria.DistrictAppealOrganizationContactIDsList) ? JsonConvert.DeserializeObject<int[]>(searchCriteria.DistrictAppealOrganizationContactIDsList) : null;
            query.ContactsToContactTypesConnectionsStatusTypesIDs = !string.IsNullOrEmpty(searchCriteria.ContactsToContactTypesConnectionsStatusTypesIDsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.ContactsToContactTypesConnectionsStatusTypesIDsList) : null;
            query.ContactRoleTypeIDs = !string.IsNullOrEmpty(searchCriteria.ContactRoleTypeIdsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.ContactRoleTypeIdsList) : null;
            query.RepositoryAppraiserAppointmentTypeIDs = !string.IsNullOrEmpty(searchCriteria.RepositoryAppraiserAppointmentTypeIDsList) ? JsonConvert.DeserializeObject<byte[]>(searchCriteria.RepositoryAppraiserAppointmentTypeIDsList) : null;
            query.City = !string.IsNullOrEmpty(searchCriteria.City) ? JsonConvert.DeserializeObject<ListItem>(searchCriteria.City) : null;



            var items = await this._contactsProvider.ContactsQuery(query);
            var dtos = items.MapList<BaseContactFlatSearchResult>();
            return dtos.ToArray();

        }
    }


}
