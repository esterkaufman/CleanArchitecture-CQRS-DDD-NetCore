using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AdminTables
    {
        public AdminTables()
        {
            InverseFkAdminTable = new HashSet<AdminTables>();
        }

        public int AdminTableID { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }
        public int? FkAdminTableID { get; set; }
        public string FkColumName { get; set; }
        public int? DisplayUpdateOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual AdminTables FkAdminTable { get; set; }
        public virtual ICollection<AdminTables> InverseFkAdminTable { get; set; }
    }
}
