using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Services.DTOs.Processes;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.Mapping;
using Newtonsoft.Json;

namespace Moj.Keshet.Services.MediatR.Queries.Contacts
{
    public class GetProcessHandler : IRequestHandler<GetProcessQuery, Process>
    {
        private readonly IProcessesProvider _processesProvider;

        public GetProcessHandler(IProcessesProvider processesProvider)
        {
            _processesProvider = processesProvider ?? throw new ArgumentNullException(nameof(processesProvider));
        }

        public async Task<Process> Handle(GetProcessQuery request, CancellationToken cancellationToken)
        {
            

            var process = await _processesProvider.GetProcessById(request.processID);               
    
            if (process == null)
            {
                return new Process();
            }

            var processDTO = process.Map<Process>();
            return processDTO;
        }
    }
    public class GetProcessesListHandler : IRequestHandler<GetProcessSearchQuery, ProcessFlatSearchResult[]>
    {
        private readonly IProcessesProvider _processesProvider;

        public GetProcessesListHandler(IProcessesProvider processesProvider)
        {
            _processesProvider = processesProvider ?? throw new ArgumentNullException(nameof(processesProvider));
        }

        public async Task<ProcessFlatSearchResult[]> Handle(GetProcessSearchQuery request, CancellationToken cancellationToken)
        {
            var searchCriteria = request.Map<Domain.Models.Processes.ProcessSearchCriteria>();
            searchCriteria.ProcessStatusIDs = JsonConvert.DeserializeObject<byte[]>(request.ProcessStatusIDsList);
            searchCriteria.AppealOrganizationIDs = JsonConvert.DeserializeObject<byte[]>(request.AppealOrganizationIDsList);
            searchCriteria.ProcessStatusIDs = JsonConvert.DeserializeObject<byte[]>(request.ProcessStatusIDsList);
            searchCriteria.BlockNumber = request.BlockNumber;
            searchCriteria.Cities = JsonConvert.DeserializeObject<ListItem[]>(request.Cities);
            searchCriteria.ProcessClientOrderNumber = request.ProcessClientOrderNumber;
            searchCriteria.PrototypeIDs = JsonConvert.DeserializeObject<byte[]>(request.PrototypeIDsList);


            var processesList = await _processesProvider.SearchAsync(searchCriteria);

            if (processesList == null)
            {
                return new ProcessFlatSearchResult[] { };
            }
            var processesDTOList = processesList.Map<ProcessFlatSearchResult[]>();
            return processesDTOList;
        }
    }
}
