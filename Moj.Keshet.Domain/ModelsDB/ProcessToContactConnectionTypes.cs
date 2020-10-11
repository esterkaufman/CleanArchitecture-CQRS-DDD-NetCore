using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessToContactConnectionTypes
    {
        public ProcessToContactConnectionTypes()
        {
            ProcessesToContactsConnections = new HashSet<ProcessesToContactsConnections>();
        }

        public byte ProcessToContactConnectionTypeID { get; set; }
        public string ProcessToContactConnectionTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessesToContactsConnections> ProcessesToContactsConnections { get; set; }
    }
}
