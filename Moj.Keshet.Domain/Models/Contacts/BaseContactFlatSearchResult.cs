using System;
using System.Collections.Generic;
using System.Text;

namespace Moj.Keshet.Domain.Models.Contacts
{
    public class BaseContactFlatSearchResult
    {
        public string ContactName { get; set; }

        public byte ContactType { get; set; }
        public string ContactsToContactTypesConnectionsStatusTypeName { get; set; }
        public string ContactSubTypeName { get; set; }
        public int ContactId { get; set; }
        public string Telephones { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }
    public class ContactPersonFlatSearchResult : BaseContactFlatSearchResult
    {
        public string DistrictAppealOrganizationContactsNames { get; set; }

        public string Department { get; set; }

        public string JobDescription { get; set; }
    }
    public class DistrictAppealOrganizationFlatSearchResult : BaseContactFlatSearchResult
    {
        public string AppealOrganizationName { get; set; }

        public string DistrictName { get; set; }

        public string Address { get; set; }


    }
    public class InterestContactFlatSearchResult : BaseContactFlatSearchResult
    {
        public string SuperContactTypeName { get; set; }

        public string IdentificationTypeName { get; set; }

        public string IdentificationNumber { get; set; }

    }
    public class AppraiserFlatSearchResult : BaseContactFlatSearchResult
    {



        public string AppoitmentDistricts { get; set; }

        public string WinningDetails { get; set; }


        public string LicenseNumber { get; set; }

        public string IdentificationNumber { get; set; }

        public string ContactRoleTypeName { get; set; }

        public string CityNameNotVerified { get; set; }

        public string AppealOrganisations { get; set; }
    }
}
