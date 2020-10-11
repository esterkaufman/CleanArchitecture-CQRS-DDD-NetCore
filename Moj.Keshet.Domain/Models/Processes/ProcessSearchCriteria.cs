using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.Enums.DatabaseEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Processes
{
    public class ProcessSearchCriteria
    {
        public byte[] ProcessSubTypeIDs { get; set; }
        public byte[] ProcessStatusIDs { get; set; }
        public long? ProcessID { get; set; }
        public ProcessTypesEnum ProcessType { get; set; }
        public byte[] AppealOrganizationIDs { get; set; }
        public int? DistrictAppealOrganizationContactId { get; set; }
        public int? ProcessAppraiserContactId { get; set; }
        public string AppraiserContactIdentificationNumber { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int[] InterestContactIDs { get; set; }
        public int[] AppraiserContactIDs { get; set; }
        public string InterestContactName { get; set; }
        public string InterestContactIdentificationNumber { get; set; }
        public string ProcessClientOrderNumber { get; set; }
        public string ProcessClientFileNumber { get; set; }
        public decimal? AppraiserFeesFrom { get; set; }
        public decimal? AppraiserFeesTo { get; set; }
        public byte[] AppraisalBusinessNeedTypeIDs { get; set; }
        public byte[] AppraisalPurposeTypeIDs { get; set; }
        public DateTime? AppraisalDateToAssignFrom { get; set; }
        public DateTime? AppraisalDateToAssignTo { get; set; }
        public int? HandlingDistrictId { get; set; }
        public ListItem[] Cities { get; set; }
        public ListItem Street { get; set; }
        public string HouseNumber { get; set; }
        public int? BlockNumber { get; set; }
        public string ClientFileNumberIsraelLandAuthority { get; set; }
        public short? FromParcelNumber { get; set; }
        public short? ToParcelNumber { get; set; }
        public string PlanCode { get; set; }
        public string FromPlot { get; set; }
        public string ToPlot { get; set; }
        public decimal? PropertyGrossAreaFrom { get; set; }
        public decimal? PropertyGrossAreaTo { get; set; }

        public long? FileId { get; set; }
        public DateTime? FromCloseDate { get; set; }
        public DateTime? ToCloseDate { get; set; }
        public decimal? AlternativeValueFrom { get; set; }
        public decimal? AlternativeValueTo { get; set; }
        public byte[] ContactSubTypeIDs { get; set; }
        public byte[] AlternativeValueCurrencyTypeIDs { get; set; }
        public byte[] AppraisalAlternativeMazamTypeIDs { get; set; }
        public byte? ExcludeProcessStatusType { get; set; }
        public string HandledBy { get; set; }

        public string QuickSearchParamerter { get; set; }
        public bool? IsPartialProcedure { get; set; }
        public byte[] PrototypeIDs { get; set; }
    }
}
