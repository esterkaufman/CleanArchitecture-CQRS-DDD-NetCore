using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisalPurposeMaamTypes
    {
        public AppraisalPurposeMaamTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
        }

        public byte AppraisalPurposeMaamTypeId { get; set; }
        public string AppraisalPurposeMaamTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
    }
}
