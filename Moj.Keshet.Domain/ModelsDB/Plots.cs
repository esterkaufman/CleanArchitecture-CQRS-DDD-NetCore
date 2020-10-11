using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Plots
    {
        public Plots()
        {
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public long PlotId { get; set; }
        public string Plot { get; set; }
        public int PlanId { get; set; }
        public bool IsActive { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
