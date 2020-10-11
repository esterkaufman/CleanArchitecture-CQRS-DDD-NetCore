using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.ModelsDB;

namespace Moj.Keshet.Repositories.Implementations.Database
{
    public partial class KeshetEntities : DbContext
{
        public virtual DbSet<AdminTables> AdminTables { get; set; }
        public virtual DbSet<AdminTablesDisabledValues> AdminTablesDisabledValues { get; set; }
        public virtual DbSet<AppealOrganizations> AppealOrganizations { get; set; }
        public virtual DbSet<AppealOrganizationsToApparaisalBusinessNeedTypesMapper> AppealOrganizationsToApparaisalBusinessNeedTypesMapper { get; set; }
        public virtual DbSet<ApplicationSettings> ApplicationSettings { get; set; }
        public virtual DbSet<ApplicationSettingsDebug> ApplicationSettingsDebug { get; set; }
        public virtual DbSet<AppraisalBusinessNeedTypes> AppraisalBusinessNeedTypes { get; set; }
        public virtual DbSet<AppraisalBusinessNeedTypesToPurposeTypesMapper> AppraisalBusinessNeedTypesToPurposeTypesMapper { get; set; }
        public virtual DbSet<AppraisalPurposeMaamTypes> AppraisalPurposeMaamTypes { get; set; }
        public virtual DbSet<AppraisalPurposeMazamTypes> AppraisalPurposeMazamTypes { get; set; }
        public virtual DbSet<AppraisalPurposeTypes> AppraisalPurposeTypes { get; set; }
        public virtual DbSet<AppraisersToDistrictsAndAppealOrganizationConnections> AppraisersToDistrictsAndAppealOrganizationConnections { get; set; }
        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CitiesNotVerified> CitiesNotVerified { get; set; }
        public virtual DbSet<CityToDistrictsMapper> CityToDistrictsMapper { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<ContactAddresses> ContactAddresses { get; set; }
        public virtual DbSet<ContactConnectionInfo> ContactConnectionInfo { get; set; }
        public virtual DbSet<ContactDegreeLevelTypes> ContactDegreeLevelTypes { get; set; }
        public virtual DbSet<ContactDegreeTypes> ContactDegreeTypes { get; set; }
        public virtual DbSet<ContactDegrees> ContactDegrees { get; set; }
        public virtual DbSet<ContactIdentites> ContactIdentites { get; set; }
        public virtual DbSet<ContactIdentityTypes> ContactIdentityTypes { get; set; }
        public virtual DbSet<ContactPhoneTypes> ContactPhoneTypes { get; set; }
        public virtual DbSet<ContactRoleTypes> ContactRoleTypes { get; set; }
        public virtual DbSet<ContactStatus> ContactStatus { get; set; }
        public virtual DbSet<ContactSubTypes> ContactSubTypes { get; set; }
        public virtual DbSet<ContactToContactConnectionTypes> ContactToContactConnectionTypes { get; set; }
        public virtual DbSet<ContactToContactConnections> ContactToContactConnections { get; set; }
        public virtual DbSet<ContactTypes> ContactTypes { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<ContactsToContactTypesConnections> ContactsToContactTypesConnections { get; set; }
        public virtual DbSet<ContactsToContactTypesConnectionsStatusTypes> ContactsToContactTypesConnectionsStatusTypes { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<DistributionFaults> DistributionFaults { get; set; }
        public virtual DbSet<DistributionObjectTypes> DistributionObjectTypes { get; set; }
        public virtual DbSet<DistributionTemplates> DistributionTemplates { get; set; }
        public virtual DbSet<DistributionTypes> DistributionTypes { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<DomainTokens> DomainTokens { get; set; }
        public virtual DbSet<FakeUsers> FakeUsers { get; set; }
        public virtual DbSet<FileToProcessesConnections> FileToProcessesConnections { get; set; }
        public virtual DbSet<FileUploadDocuments> FileUploadDocuments { get; set; }
        public virtual DbSet<FileUploadDocumentsHistory> FileUploadDocumentsHistory { get; set; }
        public virtual DbSet<FileUploadFileStatusTypes> FileUploadFileStatusTypes { get; set; }
        public virtual DbSet<FileUploadRequests> FileUploadRequests { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GenderTypes> GenderTypes { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<LandDevelopmentTypes> LandDevelopmentTypes { get; set; }
        public virtual DbSet<LdapRolesToProcessStatusesPermissions> LdapRolesToProcessStatusesPermissions { get; set; }
        public virtual DbSet<LeadingFeatureTypes> LeadingFeatureTypes { get; set; }
        public virtual DbSet<Parcels> Parcels { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Plots> Plots { get; set; }
        public virtual DbSet<ProcedureActionTypes> ProcedureActionTypes { get; set; }
        public virtual DbSet<ProcedureActionTypesToProcedureStatusTypesMapper> ProcedureActionTypesToProcedureStatusTypesMapper { get; set; }
        public virtual DbSet<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual DbSet<ProcedureNextStatusDecisions> ProcedureNextStatusDecisions { get; set; }
        public virtual DbSet<ProcedureStatusTypes> ProcedureStatusTypes { get; set; }
        public virtual DbSet<ProcedureTypes> ProcedureTypes { get; set; }
        public virtual DbSet<Procedures> Procedures { get; set; }
        public virtual DbSet<ProcessAppraisalPurposes> ProcessAppraisalPurposes { get; set; }
        public virtual DbSet<ProcessAppraisalsPurposesToPropertyIdentitiesConnections> ProcessAppraisalsPurposesToPropertyIdentitiesConnections { get; set; }
        public virtual DbSet<ProcessContactRoleTypes> ProcessContactRoleTypes { get; set; }
        public virtual DbSet<ProcessProperties> ProcessProperties { get; set; }
        public virtual DbSet<ProcessStatusReasonTypes> ProcessStatusReasonTypes { get; set; }
        public virtual DbSet<ProcessToContactConnectionTypes> ProcessToContactConnectionTypes { get; set; }
        public virtual DbSet<ProcessTypes> ProcessTypes { get; set; }
        public virtual DbSet<Processes> Processes { get; set; }
        public virtual DbSet<ProcessesToContactsConnections> ProcessesToContactsConnections { get; set; }
        public virtual DbSet<PropertiesGis> PropertiesGis { get; set; }
        public virtual DbSet<PropertiesTmp> PropertiesTmp { get; set; }
        public virtual DbSet<PropertyIdentities> PropertyIdentities { get; set; }
        public virtual DbSet<PropertyIdentityParcelStatusTypes> PropertyIdentityParcelStatusTypes { get; set; }
        public virtual DbSet<PropertyNatureTypes> PropertyNatureTypes { get; set; }
        public virtual DbSet<PropertySubTypes> PropertySubTypes { get; set; }
        public virtual DbSet<PropertyTypes> PropertyTypes { get; set; }
        public virtual DbSet<Prototypes> Prototypes { get; set; }
        public virtual DbSet<PrototypesPropertyNatureTypesMapper> PrototypesPropertyNatureTypesMapper { get; set; }
        public virtual DbSet<PrototypesUniversalCasesAddition> PrototypesUniversalCasesAddition { get; set; }
        public virtual DbSet<RepositoryAppraiserAppoitmentTypes> RepositoryAppraiserAppoitmentTypes { get; set; }
        public virtual DbSet<RepositoryAppraisersWinningDetails> RepositoryAppraisersWinningDetails { get; set; }
        public virtual DbSet<RepositoryAppraisersWinningStatuses> RepositoryAppraisersWinningStatuses { get; set; }
        public virtual DbSet<RequestActionTypes> RequestActionTypes { get; set; }
        public virtual DbSet<RequestActionTypesToRequestStatusTypesMapper> RequestActionTypesToRequestStatusTypesMapper { get; set; }
        public virtual DbSet<RequestHistory> RequestHistory { get; set; }
        public virtual DbSet<RequestNextStatusDecisions> RequestNextStatusDecisions { get; set; }
        public virtual DbSet<RequestSteps> RequestSteps { get; set; }
        public virtual DbSet<RequestTypes> RequestTypes { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<RequestsGis> RequestsGis { get; set; }
        public virtual DbSet<RequestsStatusTypes> RequestsStatusTypes { get; set; }
        public virtual DbSet<Streets> Streets { get; set; }







    }
}