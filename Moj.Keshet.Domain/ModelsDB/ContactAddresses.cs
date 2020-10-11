using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class ContactAddresses
    {
        public int ContactAddressId { get; set; }
        public int ContactId { get; set; }
        public int? CityID { get; set; }
        public string CityNameNotVerified { get; set; }
        public int? StreetID { get; set; }
        public string StreetNameNotVerified { get; set; }
        public string HouseNumber { get; set; }
        public string Entrance { get; set; }
        public string ApartmentOrRoom { get; set; }
        public string Floor { get; set; }
        public int? PostBox { get; set; }
        public int? ZipCode { get; set; }
        public bool IsPost { get; set; }
        public bool IsMain { get; set; }
        public bool IsVerified { get; set; }
        public byte[] RowVersion { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Contacts Contact { get; set; }
    }
}
