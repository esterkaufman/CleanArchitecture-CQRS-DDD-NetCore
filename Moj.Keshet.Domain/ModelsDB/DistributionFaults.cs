using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class DistributionFaults
    {
        public int DistributionFaultID { get; set; }
        public string DistributionObject { get; set; }
        public byte DistributionObjectTypeID { get; set; }
        public bool IsSent { get; set; }
    }
}
