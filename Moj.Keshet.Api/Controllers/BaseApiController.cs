using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moj.Core.Rest.Common.Logging;
using Moj.Core.Rest.Infrastructure;
using Moj.Keshet.Services.DTOs.Common;
using Moj.Keshet.Services.DTOs.Common.Security;
using Moj.Keshet.Services.DTOs.Contacts;

namespace Moj.Keshet.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.1")]
    [Route("api/base")]

    public class BaseApiController : CoreController
    {
        protected readonly IMediator _mediator;




        public BaseApiController(  IMediator mediator)
        {
            _mediator = mediator;
        }

       


              

    }
}