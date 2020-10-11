using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactToContactConnectionTypes
    {
        public ContactToContactConnectionTypes()
        {
            ContactToContactConnections = new HashSet<ContactToContactConnections>();
        }

        public byte ContactToContactConnectionTypeId { get; set; }
        public string ContactToContactConnectionTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactToContactConnections> ContactToContactConnections { get; set; }
    }
}
