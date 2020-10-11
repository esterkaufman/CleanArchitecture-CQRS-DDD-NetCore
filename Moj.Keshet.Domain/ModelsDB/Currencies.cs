using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class Currencies
    {
        public Currencies()
        {
            ProcessAppraisalPurposesDevelopmentCostCurrencyType = new HashSet<ProcessAppraisalPurposes>();
            ProcessAppraisalPurposesPurposeValueCurrencyType = new HashSet<ProcessAppraisalPurposes>();
        }

        public byte CurrencyCodeID { get; set; }
        public string CurrencyName { get; set; }
        public DateTime FromValidDate { get; set; }
        public DateTime? ToValidDate { get; set; }
        public bool IsActive { get; set; }
        public string EnumDescription { get; set; }

        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposesDevelopmentCostCurrencyType { get; set; }
        public virtual ICollection<ProcessAppraisalPurposes> ProcessAppraisalPurposesPurposeValueCurrencyType { get; set; }
    }
}
