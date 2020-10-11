using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactConnectionInfo
    {
        public int ContactId { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public byte? ContactMainPhoneTypeID { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactPhoneTypes ContactMainPhoneType { get; set; }
    }
}
