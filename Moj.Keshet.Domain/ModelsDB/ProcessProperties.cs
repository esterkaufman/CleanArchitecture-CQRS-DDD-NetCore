using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ProcessProperties
    {
        public ProcessProperties()
        {
            PropertyIdentities = new HashSet<PropertyIdentities>();
        }

        public int PropertyID { get; set; }
        public long ProcessID { get; set; }
        public byte? DistrictID { get; set; }
        public int? CityID { get; set; }
        public string CityNameNotVerified { get; set; }
        public int? StreetID { get; set; }
        public string StreetNameNotVerified { get; set; }
        public string HouseNumber { get; set; }
        public string Entrance { get; set; }
        public string Apartment { get; set; }
        public decimal? NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public string Comments { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Districts District { get; set; }
        public virtual Processes Process { get; set; }
        public virtual ICollection<PropertyIdentities> PropertyIdentities { get; set; }
    }
}
