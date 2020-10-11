using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Cities
    {
        public Cities()
        {
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
            Streets = new HashSet<Streets>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
        public virtual ICollection<Streets> Streets { get; set; }
    }
}
