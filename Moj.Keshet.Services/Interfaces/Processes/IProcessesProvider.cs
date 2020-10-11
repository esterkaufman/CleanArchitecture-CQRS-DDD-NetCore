using Moj.Keshet.Domain.Models.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Interfaces
{
    public interface IProcessesProvider
    {
        Task<ProcessFlatSearchResult[]> SearchAsync(ProcessSearchCriteria searchCriteria);
        Task<Process> GetProcessById(long processID);
    }
}
