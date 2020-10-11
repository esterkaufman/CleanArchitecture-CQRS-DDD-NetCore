using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestTypes
    {
        public RequestTypes()
        {
            RequestActionTypesToRequestStatusTypesMapper = new HashSet<RequestActionTypesToRequestStatusTypesMapper>();
            RequestNextStatusDecisions = new HashSet<RequestNextStatusDecisions>();
            Requests = new HashSet<Requests>();
        }

        public byte RequestTypeID { get; set; }
        public string RequestTypeName { get; set; }
        public byte? RequestStepID { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual RequestSteps RequestStep { get; set; }
        public virtual ICollection<RequestActionTypesToRequestStatusTypesMapper> RequestActionTypesToRequestStatusTypesMapper { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
