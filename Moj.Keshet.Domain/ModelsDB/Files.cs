using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Files
    {
        public Files()
        {
            FileToProcessesConnections = new HashSet<FileToProcessesConnections>();
        }

        public long FileID { get; set; }
        public string FileComments { get; set; }
        public byte[] RowVersion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<FileToProcessesConnections> FileToProcessesConnections { get; set; }
    }
}
