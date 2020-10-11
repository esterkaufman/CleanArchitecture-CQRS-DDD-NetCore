using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Moj.Keshet.Domain.Models.Common
{
    public class Response
    {
        public List<EntityEntry> Entries { get; set; }
    }
}
