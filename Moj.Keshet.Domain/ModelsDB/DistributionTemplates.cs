using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class DistributionTemplates
    {
        public byte TemplateID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Addressee { get; set; }
        public byte DistributionTypeID { get; set; }
        public string EnumDescription { get; set; }

        public virtual DistributionTypes DistributionType { get; set; }
    }
}
