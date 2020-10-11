using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class DomainTokens
    {
        public byte DomainId { get; set; }
        public string DomainName { get; set; }
        public Guid Token { get; set; }
    }
}
