using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessStatusReasonTypes
    {
        public ProcessStatusReasonTypes()
        {
            Processes = new HashSet<Processes>();
            RequestHistory = new HashSet<RequestHistory>();
            RequestNextStatusDecisions = new HashSet<RequestNextStatusDecisions>();
        }

        public byte ProcessStatusReasonTypeID { get; set; }
        public string ProcessStatusReasonTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<Processes> Processes { get; set; }
        public virtual ICollection<RequestHistory> RequestHistory { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
    }
}
