using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestActionTypesToRequestStatusTypesMapper
    {
        public short RequestActionTypesToRequestStatusTypesMapperID { get; set; }
        public byte RequestActionTypeID { get; set; }
        public byte RequestStatusTypeID { get; set; }
        public byte RequestTypeID { get; set; }
        public bool? IsWeb { get; set; }
        public bool IsActive { get; set; }
        public string ToolTip { get; set; }

        public virtual RequestActionTypes RequestActionType { get; set; }
        public virtual RequestsStatusTypes RequestStatusType { get; set; }
        public virtual RequestTypes RequestType { get; set; }
    }
}
