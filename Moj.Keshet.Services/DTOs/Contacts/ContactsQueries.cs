
using MediatR;

namespace Moj.Keshet.Services.DTOs.Contacts
{
    public class GetContactQuery : IRequest<Contact>
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
    }
    public class GetCompaniesQuery:IRequest<Company[]>
    {
        public int AppealOrganization { get; set; }
    }
    public class GetContactsQuery : IRequest<Contact[]>
    {
        public ContactsSearchCriteria ContactsSearchCriteria { get; set; }
      
    }
    public class GetFlatContactSearchQuery:IRequest<BaseContactFlatSearchResult[]>
    {
        public ContactsSearchCriteria ContactsSearchCriteria { get; set; }
        
    }


}
