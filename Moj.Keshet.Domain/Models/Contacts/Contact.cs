using Moj.Keshet.Domain.Models.BaseModels;
using Moj.Keshet.Domain.Models.Common.Security;
using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.CommonModelInterface;

namespace Moj.Keshet.Domain.Models.Contacts
{
    public class Contact : ExtendedEditableModel, IOperationContextData
    {
        public int ContactID { get; set; }

        public User User { get; set; }

        public ListItem[] ProcessContactRoleTypes { get; set; }
        public ListItem SuperContactType { get; set; }

        public bool? HasContactRepositoryVerification { get; set; }

        public string ContactName { get; set; } //Calculated Filed



        public Company Company { get; set; }

        public Person Person { get; set; }

        public ContactConnectionInfo ContactConnectionInfo { get; set; }
        public ContactIdentity[] ContactIdentities { get; set; }
        public UserData UserData { get; set; }
        //public ContactAddress[] ContactAddresses { get; set; }
        //public ContactToContactTypeConnection[] ContactsToContactTypesConnections { get; set; }

        //private ContactToContactTypeConnection[] _activeContactToTypesConnections;
        //protected ContactToContactTypeConnection[] ActiveContactToTypesConnections => _activeContactToTypesConnections ?? (_activeContactToTypesConnections = ContactsToContactTypesConnections.Where(x => x.ContactToContactTypeConnectionStatusType.Id == (byte)ContactsToContactTypesConnectionsStatusTypesEnum.Active).ToArray());


    }
}
