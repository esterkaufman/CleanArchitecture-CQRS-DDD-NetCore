using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Blocks
    {
        public Blocks()
        {
            Parcels = new HashSet<Parcels>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public int BlockId { get; set; }
        public int BlockNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Parcels> Parcels { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
