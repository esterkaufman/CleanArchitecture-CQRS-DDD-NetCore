using System;
using System.Collections.Generic;
using System.Text;
using Moj.Keshet.Services.DTOs.BaseModels;
using Moj.Keshet.Services.DTOs.Common.Security;
using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Shared.CommonModelInterface;

namespace Moj.Keshet.Services.DTOs.Contacts
{
    public class Contact:ExtendedEditableModel, IOperationContextData
    {
        public ContactIdentity[] ContactIdentities { get; set; }
        public int ContactID { get; set; }

        public User User { get; set; }

        public ListItem[] ProcessContactRoleTypes { get; set; }
        public ListItem SuperContactType { get; set; }

        public bool? HasContactRepositoryVerification { get; set; }

        public string ContactName { get; set; } //Calculated Filed



        public Company Company { get; set; }

        public Person Person { get; set; }

        public ContactConnectionInfo ContactConnectionInfo { get; set; }
        public UserData UserData { get; set; }
        //public ContactAddress[] ContactAddresses { get; set; }
        //public ContactToContactTypeConnection[] ContactsToContactTypesConnections { get; set; }

        //private ContactToContactTypeConnection[] _activeContactToTypesConnections;
        //protected ContactToContactTypeConnection[] ActiveContactToTypesConnections => _activeContactToTypesConnections ?? (_activeContactToTypesConnections = ContactsToContactTypesConnections.Where(x => x.ContactToContactTypeConnectionStatusType.Id == (byte)ContactsToContactTypesConnectionsStatusTypesEnum.Active).ToArray());


    }
}
