using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestNextStatusDecisions
    {
        public short RequestNextStatusDecisionID { get; set; }
        public byte? RequestActionTypeID { get; set; }
        public byte CurrentRequestStatusTypeID { get; set; }
        public byte? RequestTypeID { get; set; }
        public byte? AppraiserTypeID { get; set; }
        public byte? RequestStatusReasonTypeID { get; set; }
        public bool? IsAppraiserAwaitingControlUnit { get; set; }
        public bool? IsFuDocumentsSuccess { get; set; }
        public byte NextRequestStatusTypeID { get; set; }
        public bool? IsMissingData { get; set; }
        public byte? ProcedureStatusTypeID { get; set; }
        public bool IsActive { get; set; }

        public virtual ContactSubTypes AppraiserType { get; set; }
        public virtual RequestsStatusTypes CurrentRequestStatusType { get; set; }
        public virtual RequestsStatusTypes NextRequestStatusType { get; set; }
        public virtual ProcedureStatusTypes ProcedureStatusType { get; set; }
        public virtual RequestActionTypes RequestActionType { get; set; }
        public virtual ProcessStatusReasonTypes RequestStatusReasonType { get; set; }
        public virtual RequestTypes RequestType { get; set; }
    }
}
