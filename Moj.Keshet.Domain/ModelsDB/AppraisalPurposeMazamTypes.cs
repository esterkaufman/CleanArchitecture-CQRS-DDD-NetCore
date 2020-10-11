using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisalPurposeMazamTypes
    {
        public AppraisalPurposeMazamTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
        }

        public byte AppraisalPurposeMazamTypeID { get; set; }
        public string AppraisalPurposeMazamTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
    }
}
