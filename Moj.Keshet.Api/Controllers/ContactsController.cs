using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moj.Keshet.Services.DTOs.Contacts;

namespace Moj.Keshet.Api.Controllers
{
    [Route("api/contacts")]
    [Produces("application/json")]
    [ApiVersion("1.1")]
    [ApiController]
    public class ContactsController : BaseApiController
    {
        public ContactsController(IMediator mediator) : base(mediator)
        {
        }


        // GET: api/Mediator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var user = await _mediator.Send(new GetContactQuery { Id = id });
            return Ok(user);
        }

        [HttpGet]
        [Route("companies")]

        public async Task<ActionResult<IEnumerable<Company>>> Companies(int appealOrganizationId)
        {
            var companies = await _mediator.Send(new GetCompaniesQuery { AppealOrganization = appealOrganizationId });
            return Ok(companies);
        }
        [HttpGet]
        [Route("")]

      

        public async Task<ActionResult<IEnumerable<Contact>>> Contacts([FromHeader] ContactsSearchCriteria searchCriteria)
        {
            var contacts = await _mediator.Send(new GetFlatContactSearchQuery
            {
                ContactsSearchCriteria = searchCriteria,
               
            }) ;

            return Ok(contacts);
        }

       


    }
}
