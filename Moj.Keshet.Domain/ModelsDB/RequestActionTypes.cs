using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestActionTypes
    {
        public RequestActionTypes()
        {
            RequestActionTypesToRequestStatusTypesMapper = new HashSet<RequestActionTypesToRequestStatusTypesMapper>();
            RequestHistory = new HashSet<RequestHistory>();
            RequestNextStatusDecisions = new HashSet<RequestNextStatusDecisions>();
        }

        public byte RequestActionTypeID { get; set; }
        public string RequestActionTypeName { get; set; }
        public string RequestActionTypeImgUrl { get; set; }
        public string RequestActionTypeImgUrlOnHover { get; set; }
        public string RequestActionTypeImgUrlDisabled { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<RequestActionTypesToRequestStatusTypesMapper> RequestActionTypesToRequestStatusTypesMapper { get; set; }
        public virtual ICollection<RequestHistory> RequestHistory { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
    }
}
