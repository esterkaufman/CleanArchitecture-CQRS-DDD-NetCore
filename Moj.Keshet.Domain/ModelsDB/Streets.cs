using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Streets
    {
        public Streets()
        {
            Houses = new HashSet<Houses>();
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Houses> Houses { get; set; }
        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
