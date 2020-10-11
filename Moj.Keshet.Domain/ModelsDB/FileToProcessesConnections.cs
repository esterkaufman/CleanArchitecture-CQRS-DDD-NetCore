using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class FileToProcessesConnections
    {
        public long FileToProcessesConnectionID { get; set; }
        public long ProcessID { get; set; }
        public long FileID { get; set; }
        public bool? IsMainProcess { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Files File { get; set; }
        public virtual Processes Process { get; set; }
    }
}
