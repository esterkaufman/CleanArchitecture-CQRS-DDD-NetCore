using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Plans
    {
        public Plans()
        {
            Plots = new HashSet<Plots>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public int PlanId { get; set; }
        public string PlanCode { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Plots> Plots { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
