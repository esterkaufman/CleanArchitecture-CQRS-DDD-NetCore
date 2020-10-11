using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Houses
    {
        public Houses()
        {
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public long HouseId { get; set; }
        public int HouseNumber { get; set; }
        public int StreetId { get; set; }
        public bool IsActive { get; set; }

        public virtual Streets Street { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
