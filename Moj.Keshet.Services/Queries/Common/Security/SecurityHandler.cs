using MediatR;
using Moj.Core.Rest.Interfaces;
using Moj.Keshet.Services.DTOs.Common.Security;
using Moj.Keshet.Services.DTOs.Configuration;
using Moj.Keshet.Services.DTOs.Contacts;
using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Services.Interfaces;
using Moj.Keshet.Services.Interfaces.ListItems;
using Moj.Keshet.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Moj.Keshet.Services.Queries.Common.Security
{
    public class GetUserSecurityDataHandler : IRequestHandler<GetUserSecurityDataQuery, UserSecurityData>
    {

        private readonly IConfigurations _configurations;
        private readonly IContactsProvider _contactsProvider;
        private readonly IContactsListItemsProvider _contactsListItemsProvider;

        public GetUserSecurityDataHandler(IConfigurations configurations, IContactsProvider contactsProvider, IContactsListItemsProvider contactsListItemsProvider)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
            _contactsProvider = contactsProvider ?? throw new ArgumentNullException(nameof(contactsProvider));
            _contactsListItemsProvider = contactsListItemsProvider ?? throw new ArgumentNullException(nameof(contactsListItemsProvider));
        }

        public async Task<UserSecurityData> Handle(GetUserSecurityDataQuery request, CancellationToken cancellationToken)
        {
            var appSettingsCore = _configurations.Get<AppSettings>();
            
            var currentIdNumber = appSettingsCore.FakeUser; 
            var domainContact = await _contactsProvider.GetContactByIdNumber(currentIdNumber);
            var appealOrganization = await _contactsListItemsProvider.GetAppealOrganizationOfWorkOrderContact(domainContact.ContactID);
            var contact = domainContact.Map<Contact>();
            var ao = appealOrganization.Map<AppealOrganizationItem>();
            var user = new User
            {
                HebFirstName = contact.Person.FirstName,
                HebLastName = contact.Person.LastName,
                MailAddress = contact.ContactConnectionInfo.ContactEmail,
                UserName = currentIdNumber,
                PassportNumber = currentIdNumber,
                //City = contact.ContactAddressFormatted,
                Mobile = contact.ContactConnectionInfo.ContactMobile,
                TelephoneNumber = contact.ContactConnectionInfo.ContactPhone,
                AppealOrganization = ao
            };
            return new UserSecurityData { User = user };
        }
    }
}
