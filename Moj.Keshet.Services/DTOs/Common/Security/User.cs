using Moj.Keshet.Services.DTOs.ListItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Common.Security
{
    

    public class User
    {
        public string HebFirstName { get; set; }
        public string HebLastName { get; set; }
        public string MailAddress { get; set; }
        public string UserName { get; set; }
        public string PassportNumber { get; set; }
        public string Mobile { get; set; }
        public string TelephoneNumber { get; set; }
        public string City { get; set; }
        public AppealOrganizationItem AppealOrganization { get; set; }
    }
}
