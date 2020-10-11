using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class PrototypesUniversalCasesAddition
    {
        public int PrototypesUniversalCasesAdditionID { get; set; }
        public byte AppealOrganizationID { get; set; }
        public byte PropertyTypeId { get; set; }
        public byte PrototypeId { get; set; }
        public bool IsActive { get; set; }

        public virtual AppealOrganizations AppealOrganization { get; set; }
        public virtual PropertyTypes PropertyType { get; set; }
        public virtual Prototypes Prototype { get; set; }
    }
}
