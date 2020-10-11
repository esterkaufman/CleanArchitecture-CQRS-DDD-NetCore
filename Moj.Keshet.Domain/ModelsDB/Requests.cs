using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Requests
    {
        public Requests()
        {
            RequestHistory = new HashSet<RequestHistory>();
        }

        public long RequestId { get; set; }
        public long ProcessID { get; set; }
        public short? ExpectedWorkingDaysUpdated { get; set; }
        public byte RequestTypeID { get; set; }
        public byte RequestStatusTypeID { get; set; }
        public DateTime? RequestStatusUpdateDate { get; set; }
        public bool? IsMissingData { get; set; }
        public bool? IsAppraisalBusinessNeedOrPurposeUpdated { get; set; }
        public DateTime? RequestFillingEndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Processes Process { get; set; }
        public virtual RequestsStatusTypes RequestStatusType { get; set; }
        public virtual RequestTypes RequestType { get; set; }
        public virtual ICollection<RequestHistory> RequestHistory { get; set; }
    }
}
