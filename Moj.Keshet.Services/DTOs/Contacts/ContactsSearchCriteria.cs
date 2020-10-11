using Moj.Keshet.Services.DTOs.ListItems;
using Moj.Keshet.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Services.DTOs.Contacts
{
    /*
     * contactSubTypeIDsList: [2]
contactsToContactTypesConnectionsStatusTypesIDsList: [1]
districtIDsList: []
districtAppealOrganizationContactIDsList: []
appealOrganizationIDsList: [5]
contactRoleTypeIDsList: []
repositoryAppraiserAppointmentTypeIDsList: []
contactTypeID: 1
contactSearchType: ContactsCombo
     * */
    public class ContactsSearchCriteria
    {

        
        public string ContactIDsList { get; set; }
        public byte ContactTypeID { get; set; }

       
        public string ContactSubTypeIDsList { get; set; }

        public string DistrictIDsList { get; set; }

        public string AppealOrganizationIDsList { get; set; }


        public string DistrictAppealOrganizationContactIDsList { get; set; }

   
        public string ContactsToContactTypesConnectionsStatusTypesIDsList { get; set; }

    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string LicenseNumber { get; set; }

        public string ContactRoleTypeIdsList { get; set; }

        public string RepositoryAppraiserAppointmentTypeIDsList { get; set; }

        public string JobDescription { get; set; }

        public string IdentityNumber { get; set; }

        public string ContactName { get; set; }
        public string ContactsSearchType { get; set; }

    }
}
