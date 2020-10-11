using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PrototypesPropertyNatureTypesMapper
    {
        public byte PrototypePropertyNatureTypeMapId { get; set; }
        public short PropertyNatureTypeId { get; set; }
        public byte PrototypeId { get; set; }
        public bool IsActive { get; set; }

        public virtual PropertyNatureTypes PropertyNatureType { get; set; }
        public virtual Prototypes Prototype { get; set; }
    }
}
