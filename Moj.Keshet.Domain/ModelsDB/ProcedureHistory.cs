using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureHistory
    {
        public long ProcedureHistoryId { get; set; }
        public long ProcedureID { get; set; }
        public byte? ProcedureStatusTypeID { get; set; }
        public byte? ProcedureActionTypeID { get; set; }
        public string ActionDescription { get; set; }
        public string ProcedureComment { get; set; }
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Procedures Procedure { get; set; }
        public virtual ProcedureActionTypes ProcedureActionType { get; set; }
        public virtual ProcedureStatusTypes ProcedureStatusType { get; set; }
    }
}
