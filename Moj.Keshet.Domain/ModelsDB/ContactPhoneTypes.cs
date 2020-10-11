using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactPhoneTypes
    {
        public ContactPhoneTypes()
        {
            ContactConnectionInfo = new HashSet<ContactConnectionInfo>();
        }

        public byte PhoneTypeID { get; set; }
        public string PhoneTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactConnectionInfo> ContactConnectionInfo { get; set; }
    }
}
