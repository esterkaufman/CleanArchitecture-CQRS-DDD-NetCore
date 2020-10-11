using System;

namespace Moj.Keshet.Domain.ModelExtensions
{
    public interface ITraceData
    {
        DateTime CreateDate { get; set; }
        string CreateUser { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateUser { get; set; }
    }
}
