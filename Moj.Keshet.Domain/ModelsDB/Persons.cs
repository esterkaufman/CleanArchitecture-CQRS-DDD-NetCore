using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Persons
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstNameFromAviv { get; set; }
        public string LastNameFromAviv { get; set; }
        public string FatherNameFromAviv { get; set; }
        public DateTime? BirthDateAviv { get; set; }
        public DateTime? DeathDateAviv { get; set; }
        public byte? ContactRoleTypeID { get; set; }
        public byte? AuditorOfficeID { get; set; }
        public string Department { get; set; }
        public string JobDescription { get; set; }
        public bool? HasAppraisersRepositoryVerification { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Districts AuditorOffice { get; set; }
        public virtual Contacts Contact { get; set; }
        public virtual ContactRoleTypes ContactRoleType { get; set; }
    }
}
