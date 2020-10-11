using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class RepositoryAppraiserAppoitmentTypes
    {
        public RepositoryAppraiserAppoitmentTypes()
        {
            AppraisersToDistrictsAndAppealOrganizationConnections = new HashSet<AppraisersToDistrictsAndAppealOrganizationConnections>();
        }

        public byte RepositoryAppraiserAppoitmentTypeID { get; set; }
        public string RepositoryAppraiserAppoitmentTypeName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
    }
}
