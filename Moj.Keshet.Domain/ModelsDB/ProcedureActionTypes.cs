using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureActionTypes
    {
        public ProcedureActionTypes()
        {
            ProcedureActionTypesToProcedureStatusTypesMapper = new HashSet<ProcedureActionTypesToProcedureStatusTypesMapper>();
            ProcedureHistory = new HashSet<ProcedureHistory>();
            ProcedureNextStatusDecisions = new HashSet<ProcedureNextStatusDecisions>();
            Procedures = new HashSet<Procedures>();
        }

        public byte ProcedureActionTypeID { get; set; }
        public string ProcedureActionTypeName { get; set; }
        public string ProcedureActionTypeImgUrl { get; set; }
        public string ProcedureActionTypeImgUrlOnHover { get; set; }
        public string ProcedureActionTypeImgUrlDisabled { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcedureActionTypesToProcedureStatusTypesMapper> ProcedureActionTypesToProcedureStatusTypesMapper { get; set; }
        public virtual ICollection<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual ICollection<ProcedureNextStatusDecisions> ProcedureNextStatusDecisions { get; set; }
        public virtual ICollection<Procedures> Procedures { get; set; }
    }
}
