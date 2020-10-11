using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestHistory
    {
        public long RequestHistoryId { get; set; }
        public long ProcessID { get; set; }
        public byte? RequestStatusTypeID { get; set; }
        public byte? RequestActionTypeID { get; set; }
        public string ActionDescription { get; set; }
        public string RequestComment { get; set; }
        public byte? RequestStatusReasonTypeID { get; set; }
        public byte? AppraiserTypeID { get; set; }
        public bool? IsMissingData { get; set; }
        public bool? IsExpectedWorkingDaysUpdated { get; set; }
        public bool? IsFeesUpdated { get; set; }
        public bool? IsAppraisalTypeChangeDocumentAdded { get; set; }
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ContactSubTypes AppraiserType { get; set; }
        public virtual Requests Process { get; set; }
        public virtual RequestActionTypes RequestActionType { get; set; }
        public virtual ProcessStatusReasonTypes RequestStatusReasonType { get; set; }
        public virtual RequestsStatusTypes RequestStatusType { get; set; }
    }
}
