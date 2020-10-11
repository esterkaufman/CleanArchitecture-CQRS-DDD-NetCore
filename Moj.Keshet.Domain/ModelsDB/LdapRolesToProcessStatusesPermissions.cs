using System;
using System.Collections.Generic;

namespace Moj.Keshet.Domain.ModelsDB
{
    public partial class LdapRolesToProcessStatusesPermissions
    {
        public byte LdapRolesToProcessStatusesPermissionsID { get; set; }
        public string LdapRoleName { get; set; }
        public string ProcessStatusTypes { get; set; }
        public string LdapModuleName { get; set; }
    }
}
