using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessAppraisalsPurposesToPropertyIdentitiesConnections
    {
        public int ProcessAppraisalPurposePropertyIdentityConnectionID { get; set; }
        public int ProcessAppraisalPurposeID { get; set; }
        public int PropertyIdentityID { get; set; }
        public decimal? RamiAreaSizeInSquareMeter { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ProcessAppraisalPurposes ProcessAppraisalPurpose { get; set; }
        public virtual PropertyIdentities PropertyIdentity { get; set; }
    }
}
