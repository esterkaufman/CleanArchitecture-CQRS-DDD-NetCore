using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Parcels
    {
        public Parcels()
        {
            PropertiesGisFromParcel = new HashSet<PropertiesGis>();
            PropertiesGisToParcel = new HashSet<PropertiesGis>();
            PropertiesTmpFromParcel = new HashSet<PropertiesTmp>();
            PropertiesTmpToParcel = new HashSet<PropertiesTmp>();
        }

        public int ParcelId { get; set; }
        public decimal ParcelNumber { get; set; }
        public int BlockId { get; set; }
        public bool IsActive { get; set; }

        public virtual Blocks Block { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGisFromParcel { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGisToParcel { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmpFromParcel { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmpToParcel { get; set; }
    }
}
