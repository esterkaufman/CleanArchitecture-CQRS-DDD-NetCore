using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactsToContactTypesConnectionsStatusTypes
    {
        public ContactsToContactTypesConnectionsStatusTypes()
        {
            ContactsToContactTypesConnections = new HashSet<ContactsToContactTypesConnections>();
        }

        public byte ContactsToContactTypesConnectionsStatusTypeID { get; set; }
        public string ContactsToContactTypesConnectionsStatusTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactsToContactTypesConnections> ContactsToContactTypesConnections { get; set; }
    }
}
