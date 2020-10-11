using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactIdentites
    {
        public int ContactIdentityID { get; set; }
        public int ContactID { get; set; }
        public byte ContactIdentityTypeID { get; set; }
        public string IdentityNumber { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactIdentityTypes ContactIdentityType { get; set; }
    }
}
