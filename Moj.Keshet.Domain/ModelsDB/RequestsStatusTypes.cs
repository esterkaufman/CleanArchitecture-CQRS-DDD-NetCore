using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestsStatusTypes
    {
        public RequestsStatusTypes()
        {
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
            RequestActionTypesToRequestStatusTypesMapper = new HashSet<RequestActionTypesToRequestStatusTypesMapper>();
            RequestHistory = new HashSet<RequestHistory>();
            RequestNextStatusDecisionsCurrentRequestStatusType = new HashSet<RequestNextStatusDecisions>();
            RequestNextStatusDecisionsNextRequestStatusType = new HashSet<RequestNextStatusDecisions>();
            Requests = new HashSet<Requests>();
        }

        public byte RequestStatusTypeId { get; set; }
        public string RequestStatusTypeName { get; set; }
        public bool? IsFinal { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }
        public string ToolTip { get; set; }

        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
        public virtual ICollection<RequestActionTypesToRequestStatusTypesMapper> RequestActionTypesToRequestStatusTypesMapper { get; set; }
        public virtual ICollection<RequestHistory> RequestHistory { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisionsCurrentRequestStatusType { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisionsNextRequestStatusType { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
