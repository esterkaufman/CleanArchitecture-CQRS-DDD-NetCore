using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RepositoryAppraisersWinningDetails
    {
        public int RepositoryAppraisersWinningDetailsID { get; set; }
        public int ContactID { get; set; }
        public byte DistrictID { get; set; }
        public short EntryYear { get; set; }
        public byte RepositoryAppraisersWinningStatusID { get; set; }
        public short CommitteeGrade { get; set; }
        public short DistrictGrade { get; set; }
        public string Comments { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Districts District { get; set; }
        public virtual RepositoryAppraisersWinningStatuses RepositoryAppraisersWinningStatus { get; set; }
    }
}
