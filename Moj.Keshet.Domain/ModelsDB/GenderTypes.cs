using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class GenderTypes
    {
        public byte GenderTypeID { get; set; }
        public string GenderTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }
    }
}
