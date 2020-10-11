using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RepositoryAppraisersWinningStatuses
    {
        public RepositoryAppraisersWinningStatuses()
        {
            RepositoryAppraisersWinningDetails = new HashSet<RepositoryAppraisersWinningDetails>();
        }

        public byte RepositoryAppraisersWinningStatusID { get; set; }
        public string RepositoryAppraisersWinningStatusName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<RepositoryAppraisersWinningDetails> RepositoryAppraisersWinningDetails { get; set; }
    }
}
