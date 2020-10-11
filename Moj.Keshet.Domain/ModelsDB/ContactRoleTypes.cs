using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactRoleTypes
    {
        public ContactRoleTypes()
        {
            Persons = new HashSet<Persons>();
        }

        public byte ContactRoleTypeID { get; set; }
        public string ContactRoleTypeName { get; set; }
        public byte ContactSubTypeID { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ContactSubTypes ContactSubType { get; set; }
        public virtual ICollection<Persons> Persons { get; set; }
    }
}
