using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Prototypes
    {
        public Prototypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
            PrototypesPropertyNatureTypesMapper = new HashSet<PrototypesPropertyNatureTypesMapper>();
            PrototypesUniversalCasesAddition = new HashSet<PrototypesUniversalCasesAddition>();
        }

        public byte PrototypeId { get; set; }
        public string PrototypeName { get; set; }
        public bool UniversalCases { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
        public virtual ICollection<PrototypesPropertyNatureTypesMapper> PrototypesPropertyNatureTypesMapper { get; set; }
        public virtual ICollection<PrototypesUniversalCasesAddition> PrototypesUniversalCasesAddition { get; set; }
    }
}
