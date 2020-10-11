using Moj.Keshet.Domain.Models.ListItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Processes
{
    public class ProcessProperty 
    {
        public int PropertyID { get; set; }
        public ListItem City { get; set; }
        public ListItem Street { get; set; }
        public string CityNameNotVerified { get; set; }
        public string StreetNameNotVerified { get; set; }

        public string HouseNumber { get; set; }
        public string Entrance { get; set; }
        public string Apartment { get; set; }
        public decimal? NumberOfRooms { get; set; }
        public string Floor { get; set; }
        public string Comments { get; set; }
        public PropertyIdentity[] PropertyIdentities { get; set; }


    }
}
