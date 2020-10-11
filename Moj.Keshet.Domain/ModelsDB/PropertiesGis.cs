using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PropertiesGis
    {
        public long ObjectId { get; set; }
        public long Id { get; set; }
        public long? RequestId { get; set; }
        public byte? ProcedureTypeId { get; set; }
        public byte? RequestStatusTypeId { get; set; }
        public int? BlockId { get; set; }
        public int? FromParcelId { get; set; }
        public int? ToParcelId { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public long? HouseId { get; set; }
        public int? PlanId { get; set; }
        public long? PlotId { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public byte? PrototypeId { get; set; }
        public short? PropertyNatureTypeId { get; set; }
        public byte? AppraisalPurposeTypeId { get; set; }
        public long? Value { get; set; }
        public bool? IsDollar { get; set; }
        public DateTime? ForDate { get; set; }
        public string SealAppraiser { get; set; }
        public string LeadingFeature { get; set; }
        public long AppraisalId { get; set; }
        public string Url { get; set; }
        public string Polygon { get; set; }
        public double? ShapeArea { get; set; }
        public double? ShapeLength { get; set; }

        public virtual AppraisalPurposeTypes AppraisalPurposeType { get; set; }
        public virtual Blocks Block { get; set; }
        public virtual Cities City { get; set; }
        public virtual Parcels FromParcel { get; set; }
        public virtual Houses House { get; set; }
        public virtual Plans Plan { get; set; }
        public virtual Plots Plot { get; set; }
        public virtual ProcedureTypes ProcedureType { get; set; }
        public virtual PropertyNatureTypes PropertyNatureType { get; set; }
        public virtual Prototypes Prototype { get; set; }
        public virtual RequestsGis Request { get; set; }
        public virtual RequestsStatusTypes RequestStatusType { get; set; }
        public virtual Streets Street { get; set; }
        public virtual Parcels ToParcel { get; set; }
    }
}
