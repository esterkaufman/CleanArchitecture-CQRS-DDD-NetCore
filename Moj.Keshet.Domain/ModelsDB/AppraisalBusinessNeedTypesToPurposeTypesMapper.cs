using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisalBusinessNeedTypesToPurposeTypesMapper
    {
        public AppraisalBusinessNeedTypesToPurposeTypesMapper()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
        }

        public short AppraisalBusinessNeedTypesToPurposeTypesMapperID { get; set; }
        public byte AppraisalPurposeTypeID { get; set; }
        public byte AppraisalBusinessNeedTypeID { get; set; }
        public bool IsActive { get; set; }

        public virtual AppraisalBusinessNeedTypes AppraisalBusinessNeedType { get; set; }
        public virtual AppraisalPurposeTypes AppraisalPurposeType { get; set; }
        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
    }
}
