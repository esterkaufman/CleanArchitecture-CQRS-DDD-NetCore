using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppealOrganizationsToApparaisalBusinessNeedTypesMapper
    {
        public short AppealOrganizationsToApparaisalBusinessNeedTypesMapperID { get; set; }
        public byte AppealOrganizationID { get; set; }
        public byte AppraisalBusinessNeedTypeID { get; set; }
        public bool IsActive { get; set; }

        public virtual AppealOrganizations AppealOrganization { get; set; }
        public virtual AppraisalBusinessNeedTypes AppraisalBusinessNeedType { get; set; }
    }
}
