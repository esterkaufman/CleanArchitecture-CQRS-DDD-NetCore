using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.ListItems
{
    public class GetListItemsQuery : IRequest<IList<ListItem>>
    {

        public string lookupTableName { get; set; }
        public byte module { get; set; }
        public string? parentSelectedValues;

    }
}
