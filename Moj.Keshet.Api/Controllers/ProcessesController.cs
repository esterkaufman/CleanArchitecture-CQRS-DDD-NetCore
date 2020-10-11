using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moj.Keshet.Repositiories.Proxy.Implementation;
using Moj.Keshet.Repositiories.Proxy.Interface;
using Moj.Keshet.Services.DTOs.Processes;

namespace Moj.Keshet.Api.Controllers
{
    [Route("api/processes")]
    [Produces("application/json")]
    [ApiVersion("1.1")]
    [ApiController]

    public class ProcessesController : BaseApiController
    {

        public ProcessesController(IMediator mediator ) : base(mediator)
        {
        }

        #region Get processes from DB

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ProcessFlatSearchResult[]>> SearchProcesses([FromQuery] GetProcessSearchQuery searchCriteria)
        {
            var result = await _mediator.Send(searchCriteria);
            return Ok(result);
        }

        [HttpGet("process/{processID}")]
        public async Task<ActionResult<Process>> GetProcess(long processID)
        {
            var process = await _mediator.Send(new GetProcessQuery { processID = processID });
            return Ok(process);         
        }        
       
        #endregion

    }
}
