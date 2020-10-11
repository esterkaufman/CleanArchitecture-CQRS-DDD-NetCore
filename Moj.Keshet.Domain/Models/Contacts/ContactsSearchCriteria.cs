using Moj.Keshet.Domain.Models.ListItems;
using Moj.Keshet.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Contacts
{
  public class ContactsSearchCriteria
    {
        public int[] ContactIDs { get; set; }
        public byte ContactTypeID { get; set; }
        public byte[] ContactSubTypeIDs { get; set; }
        public byte[] ContactsToContactTypesConnectionsStatusTypesIDs { get; set; }
        public byte[] DistrictIDs { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ListItem City { get; set; }
        public byte[] AppealOrganizationIDs { get; set; }
        public int[] DistrictAppealOrganizationContactIDs { get; set; }
        public string LicenseNumber { get; set; }
        public byte[] ContactRoleTypeIDs { get; set; }
        public byte[] RepositoryAppraiserAppointmentTypeIDs { get; set; }


        public string IdentityNumber { get; set; }

        public string ContactName { get; set; }

        public string JobDescription { get; set; }
        public string ContactsSearchType { get; set; }
    }
}
