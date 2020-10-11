using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactsToContactTypesConnections
    {
        public int ContactToContactTypeConnectionID { get; set; }
        public int ContactID { get; set; }
        public byte ContactTypeID { get; set; }
        public byte? ContactSubTypeID { get; set; }
        public byte ContactsToContactTypesConnectionsStatusTypeID { get; set; }
        public DateTime ConnectionStatusUpdateDate { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactSubTypes ContactSubType { get; set; }
        public virtual ContactTypes ContactType { get; set; }
        public virtual ContactsToContactTypesConnectionsStatusTypes ContactsToContactTypesConnectionsStatusType { get; set; }
    }
}
