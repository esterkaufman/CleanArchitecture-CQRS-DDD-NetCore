using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertyIdentities
    {
        public PropertyIdentities()
        {
            ProcessAppraisalsPurposesToPropertyIdentitiesConnections = new HashSet<ProcessAppraisalsPurposesToPropertyIdentitiesConnections>();
        }

        public int PropertyIdentityID { get; set; }
        public int PropertyID { get; set; }
        public int? BlockNumber { get; set; }
        public string ClientFileNumberIsraelLandAuthority { get; set; }
        public decimal? FromParcelNumber { get; set; }
        public decimal? ToParcelNumber { get; set; }
        public string SubParcel { get; set; }
        public string PlanCode { get; set; }
        public string FromPlot { get; set; }
        public string ToPlot { get; set; }
        public bool IsBlockNumberVerified { get; set; }
        public bool IsFromParcelNumberVerified { get; set; }
        public bool IsToParcelNumberVerified { get; set; }
        public bool IsPlanCodeVerified { get; set; }
        public bool IsFromPlotVerified { get; set; }
        public bool IsToPlotVerified { get; set; }
        public byte? PropertyIdentityParcelStatusTypeID { get; set; }
        public decimal? CommercialArea { get; set; }
        public decimal? GrossArea { get; set; }
        public string PropertyIdentityDescription { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public int? FromPlotNumber { get; set; }
        public int? ToPlotNumber { get; set; }

        public virtual ProcessProperties Property { get; set; }
        public virtual PropertyIdentityParcelStatusTypes PropertyIdentityParcelStatusType { get; set; }
        public virtual ICollection<ProcessAppraisalsPurposesToPropertyIdentitiesConnections> ProcessAppraisalsPurposesToPropertyIdentitiesConnections { get; set; }
    }
}
