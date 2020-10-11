using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Processes
    {
        public Processes()
        {
            FileToProcessesConnections = new HashSet<FileToProcessesConnections>();
            InverseEntityRelated = new HashSet<Processes>();
            ProcessAppraisalPurposes = new HashSet<ProcessAppraisalPurposes>();
            ProcessProperties = new HashSet<ProcessProperties>();
            ProcessesToContactsConnections = new HashSet<ProcessesToContactsConnections>();
        }

        public long ProcessID { get; set; }
        public DateTime? RequestRecievedDate { get; set; }
        public byte AppealOrganizationID { get; set; }
        public int? DistrictAppealOrganizationContactID { get; set; }
        public string ClientFileNumber { get; set; }
        public string ClientOrderNumber { get; set; }
        public DateTime? ClientOrderDate { get; set; }
        public byte AppraiserTypeID { get; set; }
        public decimal? AppraiserFees { get; set; }
        public short? ExpectedWorkingDays { get; set; }
        public byte? AppraisalBusinessNeedTypeID { get; set; }
        public bool? IsAppraiserAwaitingControlUnit { get; set; }
        public string Comments { get; set; }
        public byte ProcessTypeId { get; set; }
        public long? EntityRelatedID { get; set; }
        public byte? StatusReasonTypeID { get; set; }
        public DateTime? StatusUpdateDate { get; set; }
        public bool? IsManualClientOrderNumber { get; set; }
        public byte? HandlingDistrictID { get; set; }
        public bool? IsUnread { get; set; }
        public DateTime? ProcessDateEnd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? ChildEntityID { get; set; }

        public virtual AppealOrganizations AppealOrganization { get; set; }
        public virtual AppraisalBusinessNeedTypes AppraisalBusinessNeedType { get; set; }
        public virtual ContactSubTypes AppraiserType { get; set; }
        public virtual Companies DistrictAppealOrganizationContact { get; set; }
        public virtual Processes EntityRelated { get; set; }
        public virtual Districts HandlingDistrict { get; set; }
        public virtual ProcessTypes ProcessType { get; set; }
        public virtual ProcessStatusReasonTypes StatusReasonType { get; set; }
        public virtual Procedures Procedures { get; set; }
        public virtual Requests Requests { get; set; }
        public virtual ICollection<FileToProcessesConnections> FileToProcessesConnections { get; set; }
        public virtual ICollection<Processes> InverseEntityRelated { get; set; }
        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
        public virtual ICollection<ProcessProperties> ProcessProperties { get; set; }
        public virtual ICollection<ProcessesToContactsConnections> ProcessesToContactsConnections { get; set; }
    }
}
