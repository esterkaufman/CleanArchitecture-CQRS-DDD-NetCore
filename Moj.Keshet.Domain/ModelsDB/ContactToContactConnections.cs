using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactToContactConnections
    {
        public int ContactToContactConnectionID { get; set; }
        public byte? ContactToContactConnectionTypeID { get; set; }
        public int FromContactID { get; set; }
        public int ToContactID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ContactToContactConnectionTypes ContactToContactConnectionType { get; set; }
        public virtual Contacts FromContact { get; set; }
        public virtual Contacts ToContact { get; set; }
    }
}
