using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactDegreeTypes
    {
        public ContactDegreeTypes()
        {
            ContactDegrees = new HashSet<ContactDegrees>();
        }

        public short ContactDegreeTypeID { get; set; }
        public string ContactDegreeTypeName { get; set; }
        public byte ContactDegreeLevelTypeID { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ContactDegreeLevelTypes ContactDegreeLevelType { get; set; }
        public virtual ICollection<ContactDegrees> ContactDegrees { get; set; }
    }
}
