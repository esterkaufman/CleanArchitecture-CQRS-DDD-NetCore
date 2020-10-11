using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class DistributionTypes
    {
        public DistributionTypes()
        {
            DistributionTemplates = new HashSet<DistributionTemplates>();
        }

        public byte DistributionTypeID { get; set; }
        public string DistributionTypeName { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<DistributionTemplates> DistributionTemplates { get; set; }
    }
}
