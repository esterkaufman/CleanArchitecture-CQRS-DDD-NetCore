using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureActionTypesToProcedureStatusTypesMapper
    {
        public short ProcedureActionTypesToProcedureStatusTypesMapperID { get; set; }
        public byte ProcedureActionTypeID { get; set; }
        public byte ProcedureStatusTypeID { get; set; }
        public byte ProcedureTypeID { get; set; }
        public bool? IsPartial { get; set; }
        public bool IsActive { get; set; }
        public string ToolTip { get; set; }

        public virtual ProcedureActionTypes ProcedureActionType { get; set; }
        public virtual ProcedureStatusTypes ProcedureStatusType { get; set; }
        public virtual ProcedureTypes ProcedureType { get; set; }
    }
}
