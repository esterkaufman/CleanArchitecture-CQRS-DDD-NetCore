using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moj.Core.Rest.Common.Logging;
using Moj.Keshet.Services.DTOs.Common;
using Moj.Keshet.Services.DTOs.Common.Security;
using Moj.Keshet.Services.DTOs.Contacts;
using System.Threading.Tasks;

namespace Moj.Keshet.Api.Controllers
{
    [Route("api/common")]
    [Produces("application/json")]
    [ApiVersion("1.1")]
    [ApiController]
    public class CommonController : BaseApiController
    {

        public CommonController(IMediator mediator) : base(mediator)
        {

        }

        //Need to move to mediator, get id from appSettings
        [HttpGet]
        [Route("userSecurityData")]
        public async Task<ActionResult<UserSecurityData>> GetUserSecurityData()
        {
            var result = await _mediator.Send(new GetUserSecurityDataQuery { });
            return Ok(result);
        }

        [HttpPost]

        public ActionResult LogClientMessage([FromBody] LogMessage logMessage)
        {
            var level = logMessage.IsError ? LogLevel.Error : LogLevel.Info;
            //AppFacade.Log(level, logMessage.Message);
            return Ok();
        }




    }
}
