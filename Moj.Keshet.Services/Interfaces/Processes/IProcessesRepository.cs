using Moj.Keshet.Domain.Models.Processes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Interfaces
{
    public interface IProcessesRepository 
    {

        Task<Process> GetProcessById(long processID);

        Task<ProcessFlatSearchResult[]> SearchAsync(ProcessSearchCriteria searchCriteria, bool isBO);
    }
}
