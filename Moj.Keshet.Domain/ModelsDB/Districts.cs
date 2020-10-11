using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Districts
    {
        public Districts()
        {
            AppraisersToDistrictsAndAppealOrganizationConnections = new HashSet<AppraisersToDistrictsAndAppealOrganizationConnections>();
            CityToDistrictsMapper = new HashSet<CityToDistrictsMapper>();
            Companies = new HashSet<Companies>();
            Persons = new HashSet<Persons>();
            ProcessProperties = new HashSet<ProcessProperties>();
            Processes = new HashSet<Processes>();
            RepositoryAppraisersWinningDetails = new HashSet<RepositoryAppraisersWinningDetails>();
        }

        public byte DistrictID { get; set; }
        public string DistrictName { get; set; }
        public bool? IsExternal { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
        public virtual ICollection<CityToDistrictsMapper> CityToDistrictsMapper { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Persons> Persons { get; set; }
        public virtual ICollection<ProcessProperties> ProcessProperties { get; set; }
        public virtual ICollection<Processes> Processes { get; set; }
        public virtual ICollection<RepositoryAppraisersWinningDetails> RepositoryAppraisersWinningDetails { get; set; }
    }
}
