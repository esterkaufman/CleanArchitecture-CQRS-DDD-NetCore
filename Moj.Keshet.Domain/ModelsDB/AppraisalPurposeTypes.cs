using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisalPurposeTypes
    {
        public AppraisalPurposeTypes()
        {
            AppraisalBusinessNeedTypesToPurposeTypesMapper = new HashSet<AppraisalBusinessNeedTypesToPurposeTypesMapper>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public byte AppraisalPurposeTypeID { get; set; }
        public string AppraisalPurposeTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<AppraisalBusinessNeedTypesToPurposeTypesMapper> AppraisalBusinessNeedTypesToPurposeTypesMapper { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
