using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Moj.Keshet.Shared.Enums.DatabaseEnums;

namespace Moj.Keshet.Services.DTOs.Processes
{
    public class GetProcessQuery : IRequest<Process>
    {
        public long processID { get; set; }
    }
    public class GetProcessSearchQuery : IRequest<ProcessFlatSearchResult[]>
    {
        public ProcessTypesEnum ProcessType { get; set; }

        public string ProcessStatusIDsList { get; set; }
        public string AppealOrganizationIDsList { get; set; }
        public string Cities { get; set; }
        public int? BlockNumber { get; set; }
        public string PrototypeIDsList { get; set; }
        public string ProcessClientOrderNumber { get; set; }
    }




}
