using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertyIdentityParcelStatusTypes
    {
        public PropertyIdentityParcelStatusTypes()
        {
            PropertyIdentities = new HashSet<PropertyIdentities>();
        }

        public byte PropertyIdentityParcelStatusTypeID { get; set; }
        public string PropertyIdentityParcelStatusTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<PropertyIdentities> PropertyIdentities { get; set; }
    }
}
