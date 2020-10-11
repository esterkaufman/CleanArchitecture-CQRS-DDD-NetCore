using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureStatusTypes
    {
        public ProcedureStatusTypes()
        {
            ProcedureActionTypesToProcedureStatusTypesMapper = new HashSet<ProcedureActionTypesToProcedureStatusTypesMapper>();
            ProcedureHistory = new HashSet<ProcedureHistory>();
            ProcedureNextStatusDecisionsCurrentProcedureStatusType = new HashSet<ProcedureNextStatusDecisions>();
            ProcedureNextStatusDecisionsNextProcedureStatusType = new HashSet<ProcedureNextStatusDecisions>();
            Procedures = new HashSet<Procedures>();
            RequestNextStatusDecisions = new HashSet<RequestNextStatusDecisions>();
        }

        public byte ProcedureStatusTypeID { get; set; }
        public string ProcedureStatusTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }
        public string ToolTip { get; set; }

        public virtual ICollection<ProcedureActionTypesToProcedureStatusTypesMapper> ProcedureActionTypesToProcedureStatusTypesMapper { get; set; }
        public virtual ICollection<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual ICollection<ProcedureNextStatusDecisions> ProcedureNextStatusDecisionsCurrentProcedureStatusType { get; set; }
        public virtual ICollection<ProcedureNextStatusDecisions> ProcedureNextStatusDecisionsNextProcedureStatusType { get; set; }
        public virtual ICollection<Procedures> Procedures { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
    }
}
