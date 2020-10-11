using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactIdentityTypes
    {
        public ContactIdentityTypes()
        {
            ContactIdentites = new HashSet<ContactIdentites>();
        }

        public byte ContactIdentityTypeID { get; set; }
        public string ContactIdentityTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactIdentites> ContactIdentites { get; set; }
    }
}
