using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestSteps
    {
        public RequestSteps()
        {
            ProcedureTypes = new HashSet<ProcedureTypes>();
            RequestTypes = new HashSet<RequestTypes>();
        }

        public byte RequestStepID { get; set; }
        public string RequestStepName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcedureTypes> ProcedureTypes { get; set; }
        public virtual ICollection<RequestTypes> RequestTypes { get; set; }
    }
}
