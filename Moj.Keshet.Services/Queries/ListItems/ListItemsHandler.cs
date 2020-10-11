using MediatR;
using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Services.Mapping;
using Moj.Keshet.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Queries.ListItems
{
    public class GetListItemsHandler : IRequestHandler<GetListItemsQuery, IList<ListItem>>
    {
        private readonly IContactsListItemsProvider _contactsListItemsProvider;
        private readonly IProcessesListItemsProvider _processListItemProvider;

        public GetListItemsHandler(IContactsListItemsProvider contactsListItemsProvider, IProcessesListItemsProvider processListItemProvider)
        {
            _contactsListItemsProvider = contactsListItemsProvider ?? throw new ArgumentNullException(nameof(contactsListItemsProvider));
            _processListItemProvider = processListItemProvider ?? throw new ArgumentNullException(nameof(processListItemProvider));
        }

        public async Task<IList<ListItem>> Handle(GetListItemsQuery request, CancellationToken cancellationToken)
        {

            var list = GetListItems(request.lookupTableName, request.module, request.parentSelectedValues).ToList();
            var listItemsDTO = list.Map<IList<ListItem>>();
            return listItemsDTO;

        }

        public Domain.Models.ListItems.ListItem[] GetListItems(string lookupTableName, byte module, string? parentSelectedValues)
        {
            var tableName = (LookupTableName)Enum.Parse(typeof(LookupTableName), lookupTableName);
            switch ((ModulesEnum)module)
            {
                case ModulesEnum.Contacts:
                    return _contactsListItemsProvider.GetContactsListItems(tableName);
                case ModulesEnum.Requests:
                    return _processListItemProvider.GetProcessesListItems(tableName);

            }
            return null;

        }
    }
}
