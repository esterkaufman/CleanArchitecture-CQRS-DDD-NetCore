using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertyTypes
    {
        public PropertyTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
            PrototypesUniversalCasesAddition = new HashSet<PrototypesUniversalCasesAddition>();
        }

        public byte PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
        public virtual ICollection<PrototypesUniversalCasesAddition> PrototypesUniversalCasesAddition { get; set; }
    }
}
