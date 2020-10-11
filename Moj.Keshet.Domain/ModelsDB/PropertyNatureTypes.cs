using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertyNatureTypes
    {
        public PropertyNatureTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
            PrototypesPropertyNatureTypesMapper = new HashSet<PrototypesPropertyNatureTypesMapper>();
        }

        public short PropertyNatureTypeId { get; set; }
        public string PropertyNatureTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
        public virtual ICollection<PrototypesPropertyNatureTypesMapper> PrototypesPropertyNatureTypesMapper { get; set; }
    }
}
