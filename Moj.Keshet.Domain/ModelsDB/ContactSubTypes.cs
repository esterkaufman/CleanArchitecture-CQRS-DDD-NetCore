using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactSubTypes
    {
        public ContactSubTypes()
        {
            AppraisersToDistrictsAndAppealOrganizationConnections = new HashSet<AppraisersToDistrictsAndAppealOrganizationConnections>();
            ContactRoleTypes = new HashSet<ContactRoleTypes>();
            ContactsToContactTypesConnections = new HashSet<ContactsToContactTypesConnections>();
            Processes = new HashSet<Processes>();
            RequestHistory = new HashSet<RequestHistory>();
            RequestNextStatusDecisions = new HashSet<RequestNextStatusDecisions>();
        }

        public byte ContactSubTypeID { get; set; }
        public string ContactSubTypeName { get; set; }
        public byte ContactTypeID { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ContactTypes ContactType { get; set; }
        public virtual ICollection<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
        public virtual ICollection<ContactRoleTypes> ContactRoleTypes { get; set; }
        public virtual ICollection<ContactsToContactTypesConnections> ContactsToContactTypesConnections { get; set; }
        public virtual ICollection<Processes> Processes { get; set; }
        public virtual ICollection<RequestHistory> RequestHistory { get; set; }
        public virtual ICollection<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
    }
}
