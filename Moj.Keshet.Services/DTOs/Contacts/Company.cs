using Moj.Keshet.Services.DTOs.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Contacts
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
