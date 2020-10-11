using System;
using Moj.Core.Rest.Interfaces;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.Interfaces.ListItems;

namespace Moj.Keshet.Services.Implementations
{
    partial class Provider : IProvider
    {
        private readonly IConfigurations _configurations;
        private readonly Lazy<IProcessesRepository> _processesRepository;
        private readonly Lazy<IContactsRepository> _contactsRepository;
        private readonly IContactsListItemsProvider _contactsListItemsProvider;
        private readonly IProcessesListItemsProvider _processesListItemsProvider;


        public Provider(
                IConfigurations configurations, Lazy<IProcessesRepository> processesRepository,
                 Lazy<IContactsRepository> contactsRepository, IContactsListItemsProvider contactsListItemsProvider, IProcessesListItemsProvider processesListItemsProvider)
        {
            _configurations = configurations;
            _processesRepository = processesRepository;
            _contactsRepository = contactsRepository;
            _contactsListItemsProvider = contactsListItemsProvider;
            _processesListItemsProvider = processesListItemsProvider;
        }
    }


}
