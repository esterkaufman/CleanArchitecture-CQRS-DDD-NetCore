
using Moj.Keshet.Services.DTOs.Contacts;
using Moj.Keshet.Services.DTOs.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Processes
{
    public class Process
    {
        public long ProcessID { get; set; }
        public DateTime? RequestRecievedDate { get; set; }
        public long? EntityRelatedID { get; set; }
        public long? ChildEntityID { get; set; }

        public AppealOrganizationItem AppealOrganization { get; set; }

        public Company DistrictAppealOrganizationContact { get; set; }

        public string ClientFileNumber { get; set; }

        public string ClientOrderNumber { get; set; }

        public DateTime? ClientOrderDate { get; set; }

        public byte AppraiserTypeId { get; set; }

        public decimal? AppraiserFees { get; set; }

        public short? ExpectedWorkingDays { get; set; }


        public string Comments { get; set; }

        public ListItem ProcessType { get; set; }

        public ListItem AppraisalPurposeType { get; set; }
        public DateTime? StatusUpdateDate { get; set; }
        
        public bool IsAppraiserAwaitingControlUnit { get; set; }

        public bool? IsManualClientOrderNumber { get; set; }

        //public Procedure Procedure { get; set; }
        public Request Request { get; set; }
        //public ProcessAppraisalAlternative[] ProcessAppraisalAlternatives { get; set; }
        public ProcessProperty[] ProcessProperties { get; set; }

        //public ContactPersonFlatSearchResultModel ContactPerson { get; set; }
        public AppraiserFlatSearchResult AppraiserContact { get; set; }
        public Contact[] InterestContacts { get; set; }
        //public ProcessAction[] ProcessActionTypeList { get; set; }
        //public ProcessActionDetails ProcessActionToExecute { get; set; }

        public ListItem HandlingDistrict { get; set; }

        public bool IsPartialProcedure { get; set; }
        public long FileId { get; set; }
        public int? WorkingDays { get; set; }

        //Calculated Field
        public string DueDate { get; set; }


        protected bool IsRequest { get; private set; }
        protected byte ActionID { get; private set; }
        protected bool IsRequestObjection { get; private set; }
        protected bool IsRequestEndStatus { get; private set; }
        protected bool IsProcedureClose { get; private set; }

        protected bool IsProcedureCancel { get; private set; }

    }
}
