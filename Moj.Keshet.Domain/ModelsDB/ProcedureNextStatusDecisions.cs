using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureNextStatusDecisions
    {
        public short ProcedureNextStatusDecisionID { get; set; }
        public byte? ProcedureActionTypeID { get; set; }
        public byte CurrentProcedureStatusTypeID { get; set; }
        public byte? ProcedureTypeID { get; set; }
        public bool? IsWeb { get; set; }
        public bool? IsFuDocumentsSuccess { get; set; }
        public byte NextProcedureStatusTypeID { get; set; }
        public bool IsActive { get; set; }

        public virtual ProcedureStatusTypes CurrentProcedureStatusType { get; set; }
        public virtual ProcedureStatusTypes NextProcedureStatusType { get; set; }
        public virtual ProcedureActionTypes ProcedureActionType { get; set; }
        public virtual ProcedureTypes ProcedureType { get; set; }
    }
}
