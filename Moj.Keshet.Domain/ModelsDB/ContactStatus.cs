using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactStatus
    {
        public byte ContactStatusID { get; set; }
        public string ContactStatusName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }
    }
}
