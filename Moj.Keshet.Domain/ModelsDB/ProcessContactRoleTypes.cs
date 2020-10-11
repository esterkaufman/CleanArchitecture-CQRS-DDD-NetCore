using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessContactRoleTypes
    {
        public ProcessContactRoleTypes()
        {
            ProcessesToContactsConnections = new HashSet<ProcessesToContactsConnections>();
        }

        public byte ProcessContactRoleTypeID { get; set; }
        public string ProcessContactRoleTypeName { get; set; }
        public byte ContactTypeID { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ContactTypes ContactType { get; set; }
        public virtual ICollection<ProcessesToContactsConnections> ProcessesToContactsConnections { get; set; }
    }
}
