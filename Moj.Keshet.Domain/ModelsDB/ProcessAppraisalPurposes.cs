using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessAppraisalPurposes
    {
        public ProcessAppraisalPurposes()
        {
            ProcessAppraisalsPurposesToPropertyIdentitiesConnections = new HashSet<ProcessAppraisalsPurposesToPropertyIdentitiesConnections>();
        }

        public int AppraisalPurposeID { get; set; }
        public long ProcessID { get; set; }
        public short AppraisalBusinessNeedTypesToPurposeTypesMapperID { get; set; }
        public DateTime? AppraisalDateToAssign { get; set; }
        public byte? PropertyTypeId { get; set; }
        public byte? PropertySubTypeId { get; set; }
        public byte? ProtoTypeId { get; set; }
        public short? PropertyNatureTypeID { get; set; }
        public decimal? AreaSizeInSquareMeter { get; set; }
        public decimal? BuildAreaSizeInSquareMeter { get; set; }
        public string AppraisalPurposeComment { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? PurposeValue { get; set; }
        public byte? PurposeValueCurrencyTypeID { get; set; }
        public decimal? DevelopmentCost { get; set; }
        public byte? AppraisalPurposeMaamTypeID { get; set; }
        public byte? AppraisalPurposeMazamTypeID { get; set; }
        public byte? DevelopmentCostCurrencyTypeID { get; set; }
        public string Polygon { get; set; }
        public byte? LandDevelopmentTypeID { get; set; }
        public bool? IsFutureAppraisalDate { get; set; }

        public virtual AppraisalBusinessNeedTypesToPurposeTypesMapper AppraisalBusinessNeedTypesToPurposeTypesMapper { get; set; }
        public virtual AppraisalPurposeMaamTypes AppraisalPurposeMaamType { get; set; }
        public virtual AppraisalPurposeMazamTypes AppraisalPurposeMazamType { get; set; }
        public virtual Currencies DevelopmentCostCurrencyType { get; set; }
        public virtual LandDevelopmentTypes LandDevelopmentType { get; set; }
        public virtual Processes Process { get; set; }
        public virtual PropertyNatureTypes PropertyNatureType { get; set; }
        public virtual PropertySubTypes PropertySubType { get; set; }
        public virtual PropertyTypes PropertyType { get; set; }
        public virtual Prototypes ProtoType { get; set; }
        public virtual Currencies PurposeValueCurrencyType { get; set; }
        public virtual ICollection<ProcessAppraisalsPurposesToPropertyIdentitiesConnections> ProcessAppraisalsPurposesToPropertyIdentitiesConnections { get; set; }
    }
}
