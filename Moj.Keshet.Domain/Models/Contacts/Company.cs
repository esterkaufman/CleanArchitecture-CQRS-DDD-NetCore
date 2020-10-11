using Moj.Keshet.Domain.Models.ListItems;

namespace Moj.Keshet.Domain.Models.Contacts
{
    public class Company
    {
        public int ContactId { get; set; }
        public string CompanyOfficeHebrewName { get; set; }
        public string CompanyHebNameFromRepository { get; set; }

        public AppealOrganizationItem AppealOrganizationType { get; set; }

        public ListItem District { get; set; }
    }

    
}
