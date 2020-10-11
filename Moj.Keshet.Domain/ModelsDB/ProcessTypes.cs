using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessTypes
    {
        public ProcessTypes()
        {
            Processes = new HashSet<Processes>();
        }

        public byte ProcessTypeID { get; set; }
        public string ProcessTypeName { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<Processes> Processes { get; set; }
    }
}
