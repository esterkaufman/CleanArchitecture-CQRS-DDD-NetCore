using System.Threading.Tasks;
using Moj.Keshet.Domain.Models.Contacts;
using Moj.Keshet.Domain.Models.ListItems;

namespace Moj.Keshet.Services.Interfaces
{
    public interface IContactsProvider
    {
        Task<Contact> GetContact(int id);
        Task<Contact> GetContactByIdNumber(string idNumber);
        Task<Company[]> GetCompanies(int appealOrganization);
        Task<Contact[]> GetContacts(ContactsSearchCriteria contactsSearchCriteria);
        Task<BaseContactFlatSearchResult[]> ContactsQuery(ContactsSearchCriteria contactsSearchCriteria);
        Task<AppealOrganizationItem> GetAppealOrganizationOfWorkOrderContact(int WorkOrderContactId);


    }
}
