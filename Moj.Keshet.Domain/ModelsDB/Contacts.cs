using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Contacts
    {
        public Contacts()
        {
            AppraisersToDistrictsAndAppealOrganizationConnections = new HashSet<AppraisersToDistrictsAndAppealOrganizationConnections>();
            ContactAddresses = new HashSet<ContactAddresses>();
            ContactDegrees = new HashSet<ContactDegrees>();
            ContactIdentites = new HashSet<ContactIdentites>();
            ContactToContactConnectionsFromContact = new HashSet<ContactToContactConnections>();
            ContactToContactConnectionsToContact = new HashSet<ContactToContactConnections>();
            ContactsToContactTypesConnections = new HashSet<ContactsToContactTypesConnections>();
            ProcessesToContactsConnections = new HashSet<ProcessesToContactsConnections>();
            RepositoryAppraisersWinningDetails = new HashSet<RepositoryAppraisersWinningDetails>();
        }

        public int ContactId { get; set; }
        public bool? HasContactRepositoryVerification { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Companies Companies { get; set; }
        public virtual ContactConnectionInfo ContactConnectionInfo { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual ICollection<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
        public virtual ICollection<ContactAddresses> ContactAddresses { get; set; }
        public virtual ICollection<ContactDegrees> ContactDegrees { get; set; }
        public virtual ICollection<ContactIdentites> ContactIdentites { get; set; }
        public virtual ICollection<ContactToContactConnections> ContactToContactConnectionsFromContact { get; set; }
        public virtual ICollection<ContactToContactConnections> ContactToContactConnectionsToContact { get; set; }
        public virtual ICollection<ContactsToContactTypesConnections> ContactsToContactTypesConnections { get; set; }
        public virtual ICollection<ProcessesToContactsConnections> ProcessesToContactsConnections { get; set; }
        public virtual ICollection<RepositoryAppraisersWinningDetails> RepositoryAppraisersWinningDetails { get; set; }
    }
}
