using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class AppealOrganizations
    {
        public AppealOrganizations()
        {
            AppealOrganizationsToApparaisalBusinessNeedTypesMapper = new HashSet<AppealOrganizationsToApparaisalBusinessNeedTypesMapper>();
            AppraisersToDistrictsAndAppealOrganizationConnections = new HashSet<AppraisersToDistrictsAndAppealOrganizationConnections>();
            Companies = new HashSet<Companies>();
            Processes = new HashSet<Processes>();
            PrototypesUniversalCasesAddition = new HashSet<PrototypesUniversalCasesAddition>();
        }

        public byte AppealOrganizationID { get; set; }
        public string AppealOrganizationName { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<AppealOrganizationsToApparaisalBusinessNeedTypesMapper> AppealOrganizationsToApparaisalBusinessNeedTypesMapper { get; set; }
        public virtual ICollection<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Processes> Processes { get; set; }
        public virtual ICollection<PrototypesUniversalCasesAddition> PrototypesUniversalCasesAddition { get; set; }
    }
}
