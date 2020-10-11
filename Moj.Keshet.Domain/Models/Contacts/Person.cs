using Moj.Keshet.Domain.Models.ListItems;
using System;

namespace Moj.Keshet.Domain.Models.Contacts
{
    public class Person 
    {
         public string FirstName { get; set; }

       public string LastName { get; set; }

        public ListItem ContactRoleType { get; set; }

        public string Department { get; set; }

         public string JobDescription { get; set; }

        public string FirstNameFromAviv { get; set; }

        public string LastNameFromAviv { get; set; }

         public string FatherNameFromAviv { get; set; }

        public DateTime? BirthDateAviv { get; set; }

        public DateTime? DeathDateAviv { get; set; }
        public bool? HasAppraisersRepositoryVerification { get; set; }

        //Calculated field->Needed for AppealOrganizations Dropdown on the ContactPerson Add\Update screen
        public AppealOrganizationItem AppealOrganizationType { get; set; }
    }
}
