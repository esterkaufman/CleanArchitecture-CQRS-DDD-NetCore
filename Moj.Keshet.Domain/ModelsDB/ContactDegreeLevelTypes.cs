using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactDegreeLevelTypes
    {
        public ContactDegreeLevelTypes()
        {
            ContactDegreeTypes = new HashSet<ContactDegreeTypes>();
        }

        public byte ContactDegreeLevelTypeID { get; set; }
        public string ContactDegreeLevelTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ContactDegreeTypes> ContactDegreeTypes { get; set; }
    }
}
