using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class CityToDistrictsMapper
    {
        public int CityToDistrictMapperID { get; set; }
        public int CityID { get; set; }
        public byte DistrictID { get; set; }

        public virtual Districts District { get; set; }
    }
}
