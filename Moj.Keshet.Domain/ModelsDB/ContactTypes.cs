using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactTypes
    {
        public ContactTypes()
        {
            ContactSubTypes = new HashSet<ContactSubTypes>();
            ContactsToContactTypesConnections = new HashSet<ContactsToContactTypesConnections>();
            ProcessContactRoleTypes = new HashSet<ProcessContactRoleTypes>();
        }

        public byte ContactTypeID { get; set; }
        public string ContactTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactSubTypes> ContactSubTypes { get; set; }
        public virtual ICollection<ContactsToContactTypesConnections> ContactsToContactTypesConnections { get; set; }
        public virtual ICollection<ProcessContactRoleTypes> ProcessContactRoleTypes { get; set; }
    }
}
