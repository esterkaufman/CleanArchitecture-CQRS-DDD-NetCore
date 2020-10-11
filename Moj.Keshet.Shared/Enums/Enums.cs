using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Shared.Enums
{    public enum ModulesEnum
    {
        Contacts,
        Requests,
        Files,
        Procedures,
        Processes
    }
    public enum SuperContactTypesEnum
    {
        PersonContact = 1,
        CompanyContact = 2
    }
    public enum ObjectState
    {
        Unchanged = 1,
        Added = 2,
        Modified = 4,
        Deleted = 8
    }
    public enum ContactsSearchTypesEnum
    {
        SearchScreen,
        ContactsCombo,
        ContactIdOnly
    }
    
}
