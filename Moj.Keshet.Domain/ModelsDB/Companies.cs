using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Companies
    {
        public Companies()
        {
            Processes = new HashSet<Processes>();
        }

        public int ContactId { get; set; }
        public string CompanyOfficeHebrewName { get; set; }
        public string CompanyHebNameFromRepository { get; set; }
        public byte? AppealOrganizationID { get; set; }
        public byte? DistrictID { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual AppealOrganizations AppealOrganization { get; set; }
        public virtual Contacts Contact { get; set; }
        public virtual Districts District { get; set; }
        public virtual ICollection<Processes> Processes { get; set; }
    }
}
