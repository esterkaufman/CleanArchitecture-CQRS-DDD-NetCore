using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class LandDevelopmentTypes
    {
        public LandDevelopmentTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
        }

        public byte LandDevelopmentTypeID { get; set; }
        public string LandDevelopmentTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
    }
}
