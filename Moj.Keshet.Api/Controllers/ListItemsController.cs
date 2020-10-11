using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Services.Interfaces;

namespace Moj.Keshet.Api.Controllers
{
    [Route("api/ListItems")]
    [Produces("application/json")]
    [ApiVersion("1.1")]
    [ApiController]
    public class ListItemsController : BaseApiController
    {

        public ListItemsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("Items")]
        public Task<ActionResult<IList<ListItem>>> GetListItems(byte module, string lookupTableName)
        {
            return GetListItemsQueryResult(module, lookupTableName);
        }

        [HttpGet("Parents/Items")]
        public Task<ActionResult<IList<ListItem>>> GetListItemsByParents(byte module, string lookupTableName, string parentSelectedValues)
        {

            return GetListItemsQueryResult(module, lookupTableName, parentSelectedValues);
        }

        [HttpGet("Parent/Items")]
        public Task<ActionResult<IList<ListItem>>> GetListItemsByParent(byte module, string lookupTableName, int parentId)
        {
            return GetListItemsQueryResult(module, lookupTableName, $"[{parentId}]");
        }

        [HttpGet("Mapper/Items")]
        public Task<ActionResult<IList<ListItem>>> GetListItemsByMapper(byte module, string lookupTableName, string parentSelectedValues)
        {
            //return GetListItemsByMapper(lookupTableName, parentSelectedValues, GetListItemsByMapperFunc((ModulesEnum)module));
            return null;
        }

        [HttpGet("Cities")]
        public Task<ActionResult<IList<ListItem>>> GetCities()
        {
            //return Ok(AppFacade.GetCities());
            return null;
        }

        [HttpGet("Streets")]
        public Task<ActionResult<IList<ListItem>>> GetStreetsByCityID([FromQuery] int cityID)
        {
            //return Ok(AppFacade.GetStreetsByCityID(cityID));
            return null;
        }

        private async Task<ActionResult<IList<ListItem>>> GetListItemsQueryResult(byte module, string lookupTableName, string? parentSelectedValues = null)
        {
            var list = await _mediator.Send(new GetListItemsQuery
            {
                module = module,
                lookupTableName = lookupTableName,
                parentSelectedValues = parentSelectedValues
            });
            return Ok(list);
        }
    }
}
