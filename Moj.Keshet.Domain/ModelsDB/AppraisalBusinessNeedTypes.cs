using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisalBusinessNeedTypes
    {
        public AppraisalBusinessNeedTypes()
        {
            AppealOrganizationsToApparaisalBusinessNeedTypesMapper = new HashSet<AppealOrganizationsToApparaisalBusinessNeedTypesMapper>();
            AppraisalBusinessNeedTypesToPurposeTypesMapper = new HashSet<AppraisalBusinessNeedTypesToPurposeTypesMapper>();
            Processes = new HashSet<Processes>();
        }

        public byte AppraisalBusinessNeedTypeID { get; set; }
        public string AppraisalBusinessNeedTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<AppealOrganizationsToApparaisalBusinessNeedTypesMapper> AppealOrganizationsToApparaisalBusinessNeedTypesMapper { get; set; }
        public virtual ICollection<AppraisalBusinessNeedTypesToPurposeTypesMapper> AppraisalBusinessNeedTypesToPurposeTypesMapper { get; set; }
        public virtual ICollection<Processes> Processes { get; set; }
    }
}
