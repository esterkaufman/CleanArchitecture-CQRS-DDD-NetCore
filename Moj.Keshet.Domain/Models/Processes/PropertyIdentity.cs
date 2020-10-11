using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Processes
{
    public class PropertyIdentity
    {
        public int PropertyIdentityID { get; set; }

        public int PropertyID { get; set; }

        public int? BlockNumber { get; set; }

        public decimal? FromParcelNumber { get; set; }

        public decimal? ToParcelNumber { get; set; }

        public string SubParcel { get; set; }

        public string PlanCode { get; set; }

        public string FromPlot { get; set; }

        public string ToPlot { get; set; }



        public string ClientFileNumberIsraelLandAuthority { get; set; }

        public bool? IsBlockNumberVerified { get; set; }

        public bool? IsFromParcelNumberVerified { get; set; }

        public bool? IsToParcelNumberVerified { get; set; }

        public bool? IsPlanCodeVerified { get; set; }

        public bool? IsFromPlotVerified { get; set; }

        public bool? IsToPlotVerified { get; set; }

        public ListItem ParcelStatusType { get; set; }

        public decimal? CommercialArea { get; set; }

        public decimal? GrossArea { get; set; }

        public string PropertyIdentityDescription { get; set; }


    }
}
