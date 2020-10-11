using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcedureTypes
    {
        public ProcedureTypes()
        {
            ProcedureActionTypesToProcedureStatusTypesMapper = new HashSet<ProcedureActionTypesToProcedureStatusTypesMapper>();
            ProcedureNextStatusDecisions = new HashSet<ProcedureNextStatusDecisions>();
            Procedures = new HashSet<Procedures>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public byte ProcedureTypeId { get; set; }
        public string ProcedureTypeName { get; set; }
        public byte? RequestStepID { get; set; }
        public bool IsChecked { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGis { get; set; }
        public string EnumDescription { get; set; }

        public virtual RequestSteps RequestStep { get; set; }
        public virtual ICollection<ProcedureActionTypesToProcedureStatusTypesMapper> ProcedureActionTypesToProcedureStatusTypesMapper { get; set; }
        public virtual ICollection<ProcedureNextStatusDecisions> ProcedureNextStatusDecisions { get; set; }
        public virtual ICollection<Procedures> Procedures { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
