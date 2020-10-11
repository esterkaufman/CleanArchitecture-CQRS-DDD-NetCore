using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Procedures
    {
        public Procedures()
        {
            ProcedureHistory = new HashSet<ProcedureHistory>();
        }

        public long ProcedureId { get; set; }
        public long ProcessID { get; set; }
        public byte ProcedureStatusTypeID { get; set; }
        public byte ProcedureTypeID { get; set; }
        public DateTime? ProcedureStartDate { get; set; }
        public DateTime? ProcedureEndToDate { get; set; }
        public byte? LastProcedureActionID { get; set; }
        public string ProcedureComments { get; set; }
        public bool? IsAppraisalBusinessNeedOrPurposeChanged { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ProcedureActionTypes LastProcedureAction { get; set; }
        public virtual ProcedureStatusTypes ProcedureStatusType { get; set; }
        public virtual ProcedureTypes ProcedureType { get; set; }
        public virtual Processes Process { get; set; }
        public virtual ICollection<ProcedureHistory> ProcedureHistory { get; set; }
    }
}
