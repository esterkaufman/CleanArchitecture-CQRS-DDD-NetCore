using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class LeadingFeatureTypes
    {
        public byte LeadingFeatureTypeId { get; set; }
        public string LeadingFeatureTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }
    }
}
