using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertySubTypes
    {
        public PropertySubTypes()
        {
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
        }

        public byte PropertySubTypeID { get; set; }
        public byte PropertyTypeID { get; set; }
        public string PropertySubTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
    }
}
