using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactDegrees
    {
        public int ContactDegreeID { get; set; }
        public int ContactID { get; set; }
        public short ContactDegreeTypeID { get; set; }
        public string DegreeDescription { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactDegreeTypes ContactDegreeType { get; set; }
    }
}
