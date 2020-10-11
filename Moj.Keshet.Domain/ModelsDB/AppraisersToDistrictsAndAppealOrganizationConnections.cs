using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppraisersToDistrictsAndAppealOrganizationConnections
    {
        public int AppraisersToDistrictsAndAppealOrganizationConnectionID { get; set; }
        public int ContactID { get; set; }
        public byte ContactSubTypeID { get; set; }
        public byte DistrictID { get; set; }
        public byte? AppealOrganizationID { get; set; }
        public byte? RepositoryAppraiserAppoitmentTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Comments { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual AppealOrganizations AppealOrganization { get; set; }
        public virtual Contacts Contact { get; set; }
        public virtual ContactSubTypes ContactSubType { get; set; }
        public virtual Districts District { get; set; }
        public virtual RepositoryAppraiserAppoitmentTypes RepositoryAppraiserAppoitmentType { get; set; }
    }
}
