using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Interfaces
{
    public interface IContactsRepository
    {
        Task<Contact> GetContact(int id);
        Task<Contact> GetContactByIdNumber(string idNumber);
        Task<Company[]> GetCompanies(int appealOrganization);
        Task<Contact[]> GetContacts(ContactsSearchCriteria contactsSearchCriteria);
        Task<BaseContactFlatSearchResult[]> GetBaseContactsByTypeAndId(byte contactTypeID, int[] contactIDs);
        
        Task<BaseContactFlatSearchResult[]> ContactsQuery(ContactsSearchCriteria contactsSearchCriteria);
        Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId);
    }
}
