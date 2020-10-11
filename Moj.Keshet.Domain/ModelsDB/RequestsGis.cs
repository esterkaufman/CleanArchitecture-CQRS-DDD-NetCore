using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RequestsGis
    {
        public RequestsGis()
        {
            PropertiesGis = new HashSet<PropertiesGis>();
            PropertiesTmp = new HashSet<PropertiesTmp>();
        }

        public long RequestId { get; set; }
        public long RequestNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PropertiesGis> PropertiesGis { get; set; }
        public virtual ICollection<PropertiesTmp> PropertiesTmp { get; set; }
    }
}
