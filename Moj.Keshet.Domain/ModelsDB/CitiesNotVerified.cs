using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class CitiesNotVerified
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}
