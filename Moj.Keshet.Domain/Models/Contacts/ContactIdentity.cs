using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Contacts
{
    public class ContactIdentity
    {
        public int ContactIdentityID { get; set; }

        public ListItem ContactIdentityType { get; set; }


        public string IdentityNumber { get; set; }

    }
}
