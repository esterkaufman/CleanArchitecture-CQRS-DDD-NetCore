using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessesToContactsConnections
    {
        public int ProcessToContactsConnectionID { get; set; }
        public int ContactID { get; set; }
        public long ProcessID { get; set; }
        public byte ProcessToContactConnectionTypeID { get; set; }
        public byte? ProcessContactRoleTypeID { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Processes Process { get; set; }
        public virtual ProcessContactRoleTypes ProcessContactRoleType { get; set; }
        public virtual ProcessToContactConnectionTypes ProcessToContactConnectionType { get; set; }
    }
}
