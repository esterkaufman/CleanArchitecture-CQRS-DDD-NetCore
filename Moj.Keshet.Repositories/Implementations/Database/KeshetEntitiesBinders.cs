using Microsoft.EntityFrameworkCore;
using Moj.Keshet.Domain.ModelsDB;

namespace Moj.Keshet.Repositories.Implementations.Database
{
    public partial class KeshetEntities
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTables>(entity =>
            {
                entity.HasKey(e => e.AdminTableID)
                    .HasName("PK_Admin_tables");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FkColumName).HasMaxLength(100);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UpdateUser).HasMaxLength(50);

                entity.HasOne(d => d.FkAdminTable)
                    .WithMany(p => p.InverseFkAdminTable)
                    .HasForeignKey(d => d.FkAdminTableID)
                    .HasConstraintName("FK_AdminTables_AdminTables");
            });

            modelBuilder.Entity<AdminTablesDisabledValues>(entity =>
            {
                entity.ToTable("AdminTablesDisabledValues", "common");

                entity.Property(e => e.DisabledKeysCsv).IsRequired();

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<AppealOrganizations>(entity =>
            {
                entity.HasKey(e => e.AppealOrganizationID)
                    .HasName("PK_AppealOrganizationTypes");

                entity.Property(e => e.AppealOrganizationID).HasColumnName("AppealOrganizationID");

                entity.Property(e => e.AppealOrganizationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AppealOrganizationsToApparaisalBusinessNeedTypesMapper>(entity =>
            {
                entity.Property(e => e.AppealOrganizationsToApparaisalBusinessNeedTypesMapperID)
                    .HasColumnName("AppealOrganizationsToApparaisalBusinessNeedTypesMapperID")
                    .HasComment("מפתח קשר גורם ראשי מטרת שומה")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppealOrganizationID)
                    .HasColumnName("AppealOrganizationID")
                    .HasComment("מפתח גורם ראשי");

                entity.Property(e => e.AppraisalBusinessNeedTypeID)
                    .HasColumnName("AppraisalBusinessNeedTypeID")
                    .HasComment("קוד מטרת שומה");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AppealOrganization)
                    .WithMany(p => p.AppealOrganizationsToApparaisalBusinessNeedTypesMapper)
                    .HasForeignKey(d => d.AppealOrganizationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppealOrganizationsToApparaisalBusinessNeedTypesMapper_AppealOrganizations");

                entity.HasOne(d => d.AppraisalBusinessNeedType)
                    .WithMany(p => p.AppealOrganizationsToApparaisalBusinessNeedTypesMapper)
                    .HasForeignKey(d => d.AppraisalBusinessNeedTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppealOrganizationsToApparaisalBusinessNeedTypesMapper_AppraisalPurposeTypes");
            });

            modelBuilder.Entity<ApplicationSettings>(entity =>
            {
                entity.ToTable("ApplicationSettings", "common");

                entity.Property(e => e.ApplicationSettingsId).ValueGeneratedNever();

                entity.Property(e => e.DateValue).HasColumnType("datetime");

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettingDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StringValue).IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationSettingsDebug>(entity =>
            {
                entity.ToTable("ApplicationSettingsDebug", "common");

                entity.Property(e => e.ApplicationSettingsDebugID).ValueGeneratedNever();

                entity.Property(e => e.DateValue).HasColumnType("datetime");

                entity.Property(e => e.DebugMachine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StringValue).IsUnicode(false);

                entity.HasOne(d => d.ApplicationSettings)
                    .WithMany(p => p.ApplicationSettingsDebug)
                    .HasForeignKey(d => d.ApplicationSettingsID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Settings_Debug_Application_Settings");
            });

            modelBuilder.Entity<AppraisalBusinessNeedTypes>(entity =>
            {
                entity.HasKey(e => e.AppraisalBusinessNeedTypeID);

                entity.Property(e => e.AppraisalBusinessNeedTypeID).HasColumnName("AppraisalBusinessNeedTypeID");

                entity.Property(e => e.AppraisalBusinessNeedTypeName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<AppraisalBusinessNeedTypesToPurposeTypesMapper>(entity =>
            {
                entity.Property(e => e.AppraisalBusinessNeedTypesToPurposeTypesMapperID)
                    .HasColumnName("AppraisalBusinessNeedTypesToPurposeTypesMapperID")
                    .HasComment("מפתח קשר מטרת נכס למהות נכס")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppraisalBusinessNeedTypeID)
                    .HasColumnName("AppraisalBusinessNeedTypeID")
                    .HasComment("מפתח מטרת נכס");

                entity.Property(e => e.AppraisalPurposeTypeID)
                    .HasColumnName("AppraisalPurposeTypeID")
                    .HasComment("מפתח מהות נכס");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AppraisalBusinessNeedType)
                    .WithMany(p => p.AppraisalBusinessNeedTypesToPurposeTypesMapper)
                    .HasForeignKey(d => d.AppraisalBusinessNeedTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppraisalBusinessNeedTypesToPurposeTypesMapper_AppraisalBusinessNeedTypes");

                entity.HasOne(d => d.AppraisalPurposeType)
                    .WithMany(p => p.AppraisalBusinessNeedTypesToPurposeTypesMapper)
                    .HasForeignKey(d => d.AppraisalPurposeTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppraisalBusinessNeedTypesToPurposeTypesMapper_AppraisalPurposeTypes");
            });

            modelBuilder.Entity<AppraisalPurposeMaamTypes>(entity =>
            {
                entity.HasKey(e => e.AppraisalPurposeMaamTypeId);

                entity.Property(e => e.AppraisalPurposeMaamTypeId)
                    .HasComment("קוד התייחסות מע\"מ פניה")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AppraisalPurposeMaamTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("תיאור התייחסות מע\"מ פניה");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AppraisalPurposeMazamTypes>(entity =>
            {
                entity.HasKey(e => e.AppraisalPurposeMazamTypeID);

                entity.Property(e => e.AppraisalPurposeMazamTypeID)
                    .HasColumnName("AppraisalPurposeMazamTypeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AppraisalPurposeMazamTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AppraisalPurposeTypes>(entity =>
            {
                entity.HasKey(e => e.AppraisalPurposeTypeID);

                entity.Property(e => e.AppraisalPurposeTypeID).HasColumnName("AppraisalPurposeTypeID");

                entity.Property(e => e.AppraisalPurposeTypeName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppraisersToDistrictsAndAppealOrganizationConnections>(entity =>
            {
                entity.HasKey(e => e.AppraisersToDistrictsAndAppealOrganizationConnectionID);

                entity.Property(e => e.AppraisersToDistrictsAndAppealOrganizationConnectionID).HasColumnName("AppraisersToDistrictsAndAppealOrganizationConnectionID");

                entity.Property(e => e.AppealOrganizationID).HasColumnName("AppealOrganizationID");

                entity.Property(e => e.Comments).HasMaxLength(100);

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.ContactSubTypeID).HasColumnName("ContactSubTypeID");

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.RepositoryAppraiserAppoitmentTypeID).HasColumnName("RepositoryAppraiserAppoitmentTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AppealOrganization)
                    .WithMany(p => p.AppraisersToDistrictsAndAppealOrganizationConnections)
                    .HasForeignKey(d => d.AppealOrganizationID)
                    .HasConstraintName("FK_AppraisersToDistrictsAndAppealOrganizationConnections_AppealOrganizations");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.AppraisersToDistrictsAndAppealOrganizationConnections)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppraisersToDistrictsAndAppealOrganizationConnections_Contacts");

                entity.HasOne(d => d.ContactSubType)
                    .WithMany(p => p.AppraisersToDistrictsAndAppealOrganizationConnections)
                    .HasForeignKey(d => d.ContactSubTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppraisersToDistrictsAndAppealOrganizationConnections_ContactSubTypes");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.AppraisersToDistrictsAndAppealOrganizationConnections)
                    .HasForeignKey(d => d.DistrictID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppraisersToDistrictsAndAppealOrganizationConnections_Districts");

                entity.HasOne(d => d.RepositoryAppraiserAppoitmentType)
                    .WithMany(p => p.AppraisersToDistrictsAndAppealOrganizationConnections)
                    .HasForeignKey(d => d.RepositoryAppraiserAppoitmentTypeID)
                    .HasConstraintName("FK_AppraisersToDistrictsAndAppealOrganizationConnections_RepositoryAppraiserAppoitmentTypes");
            });

            modelBuilder.Entity<Blocks>(entity =>
            {
                entity.HasKey(e => e.BlockId)
                    .HasName("PK_Blocks_1");

                entity.HasIndex(e => e.BlockNumber)
                    .HasName("IX_Blocks")
                    .IsUnique();
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.HasIndex(e => e.CityName)
                    .HasName("IX_Cities")
                    .IsUnique();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CitiesNotVerified>(entity =>
            {
                entity.HasKey(e => e.CityID);

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CityToDistrictsMapper>(entity =>
            {
                entity.HasKey(e => e.CityToDistrictMapperID);

                entity.Property(e => e.CityToDistrictMapperID).HasColumnName("CityToDistrictMapperID");

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.CityToDistrictsMapper)
                    .HasForeignKey(d => d.DistrictID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityToDistrictsMapper_Districts");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.AppealOrganizationID).HasColumnName("AppealOrganizationID");

                entity.Property(e => e.CompanyHebNameFromRepository).HasMaxLength(100);

                entity.Property(e => e.CompanyOfficeHebrewName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AppealOrganization)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AppealOrganizationID)
                    .HasConstraintName("FK_Companies_AppealOrganizationTypes");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.Companies)
                    .HasForeignKey<Companies>(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Companies_Contacts");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.DistrictID)
                    .HasConstraintName("FK_Companies_Districts");
            });

            modelBuilder.Entity<ContactAddresses>(entity =>
            {
                entity.HasKey(e => e.ContactAddressId);

                entity.Property(e => e.ApartmentOrRoom).HasMaxLength(5);

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CityNameNotVerified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('.')");

                entity.Property(e => e.Entrance).HasMaxLength(5);

                entity.Property(e => e.Floor).HasMaxLength(5);

                entity.Property(e => e.HouseNumber).HasMaxLength(5);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StreetID).HasColumnName("StreetID");

                entity.Property(e => e.StreetNameNotVerified).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactAddresses)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactAddresses_Contacts");
            });

            modelBuilder.Entity<ContactConnectionInfo>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.ContactEmail).HasMaxLength(100);

                entity.Property(e => e.ContactFax).HasMaxLength(11);

                entity.Property(e => e.ContactMainPhoneTypeID).HasColumnName("ContactMainPhoneTypeID");

                entity.Property(e => e.ContactMobile).HasMaxLength(11);

                entity.Property(e => e.ContactPhone).HasMaxLength(11);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.ContactConnectionInfo)
                    .HasForeignKey<ContactConnectionInfo>(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactConnectionInfo_Contacts");

                entity.HasOne(d => d.ContactMainPhoneType)
                    .WithMany(p => p.ContactConnectionInfo)
                    .HasForeignKey(d => d.ContactMainPhoneTypeID)
                    .HasConstraintName("FK_ContactConnectionInfo_ContactPhoneTypes");
            });

            modelBuilder.Entity<ContactDegreeLevelTypes>(entity =>
            {
                entity.HasKey(e => e.ContactDegreeLevelTypeID);

                entity.Property(e => e.ContactDegreeLevelTypeID).HasColumnName("ContactDegreeLevelTypeID");

                entity.Property(e => e.ContactDegreeLevelTypeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<ContactDegreeTypes>(entity =>
            {
                entity.HasKey(e => e.ContactDegreeTypeID)
                    .HasName("PK_CustomerDegreeTypes");

                entity.Property(e => e.ContactDegreeTypeID)
                    .HasColumnName("ContactDegreeTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactDegreeLevelTypeID).HasColumnName("ContactDegreeLevelTypeID");

                entity.Property(e => e.ContactDegreeTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ContactDegreeLevelType)
                    .WithMany(p => p.ContactDegreeTypes)
                    .HasForeignKey(d => d.ContactDegreeLevelTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactDegreeTypes_ContactDegreeLevelTypes");
            });

            modelBuilder.Entity<ContactDegrees>(entity =>
            {
                entity.HasKey(e => e.ContactDegreeID);

                entity.Property(e => e.ContactDegreeID).HasColumnName("ContactDegreeID");

                entity.Property(e => e.ContactDegreeTypeID).HasColumnName("ContactDegreeTypeID");

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.DegreeDescription).HasMaxLength(100);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.ContactDegreeType)
                    .WithMany(p => p.ContactDegrees)
                    .HasForeignKey(d => d.ContactDegreeTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactDegrees_ContactDegreeTypes");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactDegrees)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactDegrees_Contacts");
            });

            modelBuilder.Entity<ContactIdentites>(entity =>
            {
                entity.HasKey(e => e.ContactIdentityID);

                entity.Property(e => e.ContactIdentityID).HasColumnName("ContactIdentityID");

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.ContactIdentityTypeID).HasColumnName("ContactIdentityTypeID");

                entity.Property(e => e.IdentityNumber).HasMaxLength(30);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactIdentites)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactIdentites_Contacts");

                entity.HasOne(d => d.ContactIdentityType)
                    .WithMany(p => p.ContactIdentites)
                    .HasForeignKey(d => d.ContactIdentityTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactIdentites_ContactIdentityTypes");
            });

            modelBuilder.Entity<ContactIdentityTypes>(entity =>
            {
                entity.HasKey(e => e.ContactIdentityTypeID)
                    .HasName("PK_ContactIdentityType");

                entity.Property(e => e.ContactIdentityTypeID).HasColumnName("ContactIdentityTypeID");

                entity.Property(e => e.ContactIdentityTypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<ContactPhoneTypes>(entity =>
            {
                entity.HasKey(e => e.PhoneTypeID);

                entity.Property(e => e.PhoneTypeID).HasColumnName("PhoneTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhoneTypeName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<ContactRoleTypes>(entity =>
            {
                entity.HasKey(e => e.ContactRoleTypeID)
                    .HasName("PK_RoleTypes");

                entity.Property(e => e.ContactRoleTypeID).HasColumnName("ContactRoleTypeID");

                entity.Property(e => e.ContactRoleTypeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ContactSubTypeID).HasColumnName("ContactSubTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ContactSubType)
                    .WithMany(p => p.ContactRoleTypes)
                    .HasForeignKey(d => d.ContactSubTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactRoleTypes_ContactSubTypes");
            });

            modelBuilder.Entity<ContactStatus>(entity =>
            {
                entity.Property(e => e.ContactStatusID).HasColumnName("ContactStatusID");

                entity.Property(e => e.ContactStatusName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<ContactSubTypes>(entity =>
            {
                entity.HasKey(e => e.ContactSubTypeID);

                entity.Property(e => e.ContactSubTypeID).HasColumnName("ContactSubTypeID");

                entity.Property(e => e.ContactSubTypeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ContactTypeID).HasColumnName("ContactTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.ContactSubTypes)
                    .HasForeignKey(d => d.ContactTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactSubTypes_ContactTypes");
            });

            modelBuilder.Entity<ContactToContactConnectionTypes>(entity =>
            {
                entity.HasKey(e => e.ContactToContactConnectionTypeId)
                    .HasName("PK_ContactTOContactType");

                entity.Property(e => e.ContactToContactConnectionTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ContactToContactConnections>(entity =>
            {
                entity.HasKey(e => e.ContactToContactConnectionID);

                entity.Property(e => e.ContactToContactConnectionID).HasColumnName("ContactToContactConnectionID");

                entity.Property(e => e.ContactToContactConnectionTypeID).HasColumnName("ContactToContactConnectionTypeID");

                entity.Property(e => e.FromContactID).HasColumnName("FromContactID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ToContactID).HasColumnName("ToContactID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.ContactToContactConnectionType)
                    .WithMany(p => p.ContactToContactConnections)
                    .HasForeignKey(d => d.ContactToContactConnectionTypeID)
                    .HasConstraintName("FK_ContactToContactConnections_ContactToContactConnectionTypes");

                entity.HasOne(d => d.FromContact)
                    .WithMany(p => p.ContactToContactConnectionsFromContact)
                    .HasForeignKey(d => d.FromContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FromcontactToContacts");

                entity.HasOne(d => d.ToContact)
                    .WithMany(p => p.ContactToContactConnectionsToContact)
                    .HasForeignKey(d => d.ToContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TocontactToContacts");
            });

            modelBuilder.Entity<ContactTypes>(entity =>
            {
                entity.HasKey(e => e.ContactTypeID)
                    .HasName("PK_cont2Type");

                entity.Property(e => e.ContactTypeID).HasColumnName("ContactTypeID");

                entity.Property(e => e.ContactTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);
            });

            modelBuilder.Entity<ContactsToContactTypesConnections>(entity =>
            {
                entity.HasKey(e => e.ContactToContactTypeConnectionID);

                entity.Property(e => e.ContactToContactTypeConnectionID).HasColumnName("ContactToContactTypeConnectionID");

                entity.Property(e => e.ConnectionStatusUpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.ContactSubTypeID).HasColumnName("ContactSubTypeID");

                entity.Property(e => e.ContactTypeID).HasColumnName("ContactTypeID");

                entity.Property(e => e.ContactsToContactTypesConnectionsStatusTypeID)
                    .HasColumnName("ContactsToContactTypesConnectionsStatusTypeID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactsToContactTypesConnections)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsToContactTypesConnections_Contacts");

                entity.HasOne(d => d.ContactSubType)
                    .WithMany(p => p.ContactsToContactTypesConnections)
                    .HasForeignKey(d => d.ContactSubTypeID)
                    .HasConstraintName("FK_ContactsToContactTypesConnections_ContactSubTypes");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.ContactsToContactTypesConnections)
                    .HasForeignKey(d => d.ContactTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsToContactTypesConnections_ContatctTypes");

                entity.HasOne(d => d.ContactsToContactTypesConnectionsStatusType)
                    .WithMany(p => p.ContactsToContactTypesConnections)
                    .HasForeignKey(d => d.ContactsToContactTypesConnectionsStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsToContactTypesConnections_ContactsToContactTypesConnectionsStatusTypes");
            });

            modelBuilder.Entity<ContactsToContactTypesConnectionsStatusTypes>(entity =>
            {
                entity.HasKey(e => e.ContactsToContactTypesConnectionsStatusTypeID);

                entity.Property(e => e.ContactsToContactTypesConnectionsStatusTypeID).HasColumnName("ContactsToContactTypesConnectionsStatusTypeID");

                entity.Property(e => e.ContactsToContactTypesConnectionsStatusTypeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyCodeID);

                entity.Property(e => e.CurrencyCodeID).HasColumnName("CurrencyCodeID");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.FromValidDate).HasColumnType("datetime");

                entity.Property(e => e.ToValidDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DistributionFaults>(entity =>
            {
                entity.HasKey(e => e.DistributionFaultID);

                entity.ToTable("DistributionFaults", "common");

                entity.Property(e => e.DistributionFaultID).HasColumnName("DistributionFaultID");

                entity.Property(e => e.DistributionObject)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.DistributionObjectTypeID).HasColumnName("DistributionObjectTypeID");
            });

            modelBuilder.Entity<DistributionObjectTypes>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();
            });

            modelBuilder.Entity<DistributionTemplates>(entity =>
            {
                entity.HasKey(e => e.TemplateID);

                entity.Property(e => e.TemplateID).HasColumnName("TemplateID");

                entity.Property(e => e.Addressee)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.DistributionTypeID).HasColumnName("DistributionTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.DistributionType)
                    .WithMany(p => p.DistributionTemplates)
                    .HasForeignKey(d => d.DistributionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistributionTemplates_DistributionTypes");
            });

            modelBuilder.Entity<DistributionTypes>(entity =>
            {
                entity.HasKey(e => e.DistributionTypeID);

                entity.Property(e => e.DistributionTypeID).HasColumnName("DistributionTypeID");

                entity.Property(e => e.DistributionTypeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasKey(e => e.DistrictID);

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DomainTokens>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.Property(e => e.DomainId).ValueGeneratedOnAdd();
                
                entity.Property(e => e.DomainName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FakeUsers>(entity =>
            {
                entity.HasKey(e => e.RealUser);

                entity.ToTable("FakeUsers", "common");

                entity.Property(e => e.RealUser).HasMaxLength(50);

                entity.Property(e => e.FakeUser).HasMaxLength(50);
            });

            modelBuilder.Entity<FileToProcessesConnections>(entity =>
            {
                entity.HasKey(e => e.FileToProcessesConnectionID);

                entity.Property(e => e.FileToProcessesConnectionID)
                    .HasColumnName("FileToProcessesConnectionID")
                    .HasComment("מפתח קשר פניה לתיק");

                entity.Property(e => e.FileID)
                    .HasColumnName("FileID")
                    .HasComment("מפתח תיק");

                entity.Property(e => e.ProcessID)
                    .HasColumnName("ProcessID")
                    .HasComment("מפתח פניה");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileToProcessesConnections)
                    .HasForeignKey(d => d.FileID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileToProcessesConnections_Files");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.FileToProcessesConnections)
                    .HasForeignKey(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileToProcessesConnections_Processes");
            });

            modelBuilder.Entity<FileUploadDocuments>(entity =>
            {
                entity.HasKey(e => e.FupDocumentID);

                entity.ToTable("FileUploadDocuments", "common");

                entity.Property(e => e.FupDocumentID).HasColumnName("FupDocumentID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.DocumentTitle).HasMaxLength(100);

                entity.Property(e => e.DocumentTypeID).HasColumnName("DocumentTypeID");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FumsAddTime).HasColumnType("datetime");

                entity.Property(e => e.FumsObject).HasColumnType("xml");

                entity.Property(e => e.FumsResponseTime).HasColumnType("datetime");

                entity.Property(e => e.FupFileStatusTypeID).HasColumnName("FupFileStatusTypeID");

                entity.Property(e => e.FupRequestID).HasColumnName("FupRequestID");

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.MojID)
                    .HasColumnName("MojID")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.FupFileStatusType)
                    .WithMany(p => p.FileUploadDocuments)
                    .HasForeignKey(d => d.FupFileStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileUploadDocuments_FileUploadFileStatusTypes");

                entity.HasOne(d => d.FupRequest)
                    .WithMany(p => p.FileUploadDocuments)
                    .HasForeignKey(d => d.FupRequestID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileUploadDocuments_FileUploadRequests");
            });

            modelBuilder.Entity<FileUploadDocumentsHistory>(entity =>
            {
                entity.HasKey(e => e.FupDocumentID);

                entity.ToTable("FileUploadDocumentsHistory", "common");

                entity.Property(e => e.FupDocumentID)
                    .HasColumnName("FupDocumentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.DocumentTitle).HasMaxLength(100);

                entity.Property(e => e.DocumentTypeID).HasColumnName("DocumentTypeID");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FumsAddTime).HasColumnType("datetime");

                entity.Property(e => e.FumsObject).HasColumnType("xml");

                entity.Property(e => e.FumsResponseTime).HasColumnType("datetime");

                entity.Property(e => e.FupFileStatusTypeID).HasColumnName("FupFileStatusTypeID");

                entity.Property(e => e.FupRequestID).HasColumnName("FupRequestID");

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.MojID)
                    .HasColumnName("MojID")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.FupFileStatusType)
                    .WithMany(p => p.FileUploadDocumentsHistory)
                    .HasForeignKey(d => d.FupFileStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileUploadDocumentsHistory_FileUploadFileStatusTypes");

                entity.HasOne(d => d.FupRequest)
                    .WithMany(p => p.FileUploadDocumentsHistory)
                    .HasForeignKey(d => d.FupRequestID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileUploadDocumentsHistory_FileUploadRequests");
            });

            modelBuilder.Entity<FileUploadFileStatusTypes>(entity =>
            {
                entity.HasKey(e => e.FupFileStatusTypeID);

                entity.ToTable("FileUploadFileStatusTypes", "common");

                entity.Property(e => e.FupFileStatusTypeID).HasColumnName("FupFileStatusTypeID");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.FupFileStatusTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<FileUploadRequests>(entity =>
            {
                entity.HasKey(e => e.FupRequestID);

                entity.ToTable("FileUploadRequests", "common");

                entity.Property(e => e.FupRequestID).HasColumnName("FupRequestID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EntityID).HasColumnName("EntityID");

                entity.Property(e => e.EntityInstanceID).HasColumnName("EntityInstanceID");

                entity.Property(e => e.FupRequestObject).HasColumnType("xml");

                entity.Property(e => e.IsPending)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentInstanceID).HasColumnName("ParentInstanceID");

                entity.Property(e => e.SenderIdNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileID);

                entity.Property(e => e.FileID)
                    .HasColumnName("FileID")
                    .HasComment("מפתח תיק ");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FileComments)
                    .HasMaxLength(500)
                    .HasComment("הערות לתיק");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);
            });

            modelBuilder.Entity<GenderTypes>(entity =>
            {
                entity.HasKey(e => e.GenderTypeID);

                entity.Property(e => e.GenderTypeID).HasColumnName("GenderTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.GenderTypeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Houses>(entity =>
            {
                entity.HasKey(e => e.HouseId);

                entity.HasIndex(e => e.HouseNumber)
                    .HasName("IX_Houses");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Houses_Streets");
            });

            modelBuilder.Entity<LandDevelopmentTypes>(entity =>
            {
                entity.HasKey(e => e.LandDevelopmentTypeID)
                    .HasName("PK__LandDeve__92CF182F179A4FBC");

                entity.Property(e => e.LandDevelopmentTypeID)
                    .HasColumnName("LandDevelopmentTypeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LandDevelopmentTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<LdapRolesToProcessStatusesPermissions>(entity =>
            {
                entity.Property(e => e.LdapRolesToProcessStatusesPermissionsID).HasColumnName("LdapRolesToProcessStatusesPermissionsID");

                entity.Property(e => e.LdapModuleName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LdapRoleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProcessStatusTypes)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LeadingFeatureTypes>(entity =>
            {
                entity.HasKey(e => e.LeadingFeatureTypeId)
                    .HasName("PK_LeadingFeatureTypeIdTypeId");

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LeadingFeatureTypeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parcels>(entity =>
            {
                entity.HasKey(e => e.ParcelId);

                entity.Property(e => e.ParcelNumber).HasColumnType("numeric(20, 0)");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Parcels)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcels_Blocks");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.ContactID)
                    .HasName("PK_PersonDATA");

                entity.Property(e => e.ContactID)
                    .HasColumnName("ContactID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditorOfficeID).HasColumnName("AuditorOfficeID");

                entity.Property(e => e.BirthDateAviv).HasColumnType("datetime");

                entity.Property(e => e.ContactRoleTypeID).HasColumnName("ContactRoleTypeID");

                entity.Property(e => e.DeathDateAviv).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.FatherNameFromAviv).HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FirstNameFromAviv).HasMaxLength(20);

                entity.Property(e => e.JobDescription).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastNameFromAviv).HasMaxLength(20);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AuditorOffice)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.AuditorOfficeID)
                    .HasConstraintName("FK_Persons_Districts");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.Persons)
                    .HasForeignKey<Persons>(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_Contacts");

                entity.HasOne(d => d.ContactRoleType)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.ContactRoleTypeID)
                    .HasConstraintName("FK_Persons_RoleTypes");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK_Planes");

                entity.HasIndex(e => e.PlanCode)
                    .HasName("IX_Plans")
                    .IsUnique();

                entity.Property(e => e.PlanCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plots>(entity =>
            {
                entity.HasKey(e => e.PlotId);

                entity.Property(e => e.Plot)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Plots)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plots_Plans");
            });

            modelBuilder.Entity<ProcedureActionTypes>(entity =>
            {
                entity.HasKey(e => e.ProcedureActionTypeID);

                entity.Property(e => e.ProcedureActionTypeID)
                    .HasColumnName("ProcedureActionTypeID")
                    .HasComment("");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon).HasMaxLength(100);

                entity.Property(e => e.ProcedureActionTypeImgUrl).HasMaxLength(500);

                entity.Property(e => e.ProcedureActionTypeImgUrlDisabled).HasMaxLength(500);

                entity.Property(e => e.ProcedureActionTypeImgUrlOnHover).HasMaxLength(500);

                entity.Property(e => e.ProcedureActionTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProcedureActionTypesToProcedureStatusTypesMapper>(entity =>
            {
                entity.Property(e => e.ProcedureActionTypesToProcedureStatusTypesMapperID)
                    .HasColumnName("ProcedureActionTypesToProcedureStatusTypesMapperID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProcedureActionTypeID).HasColumnName("ProcedureActionTypeID");

                entity.Property(e => e.ProcedureStatusTypeID).HasColumnName("ProcedureStatusTypeID");

                entity.Property(e => e.ProcedureTypeID).HasColumnName("ProcedureTypeID");

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProcedureActionType)
                    .WithMany(p => p.ProcedureActionTypesToProcedureStatusTypesMapper)
                    .HasForeignKey(d => d.ProcedureActionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureActionTypesToProcedureStatusTypesMapper_ProcedureActionTypes");

                entity.HasOne(d => d.ProcedureStatusType)
                    .WithMany(p => p.ProcedureActionTypesToProcedureStatusTypesMapper)
                    .HasForeignKey(d => d.ProcedureStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureActionTypesToProcedureStatusTypesMapper_ProcedureStatusTypes");

                entity.HasOne(d => d.ProcedureType)
                    .WithMany(p => p.ProcedureActionTypesToProcedureStatusTypesMapper)
                    .HasForeignKey(d => d.ProcedureTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureActionTypesToProcedureStatusTypesMapper_ProcedureTypes");
            });

            modelBuilder.Entity<ProcedureHistory>(entity =>
            {
                entity.Property(e => e.ActionDescription).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProcedureActionTypeID).HasColumnName("ProcedureActionTypeID");

                entity.Property(e => e.ProcedureComment).HasMaxLength(500);

                entity.Property(e => e.ProcedureID).HasColumnName("ProcedureID");

                entity.Property(e => e.ProcedureStatusTypeID).HasColumnName("ProcedureStatusTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.ProcedureActionType)
                    .WithMany(p => p.ProcedureHistory)
                    .HasForeignKey(d => d.ProcedureActionTypeID)
                    .HasConstraintName("FK_ProcedureHistory_ProcedureActionTypes");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.ProcedureHistory)
                    .HasForeignKey(d => d.ProcedureID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureHistory_Procedures");

                entity.HasOne(d => d.ProcedureStatusType)
                    .WithMany(p => p.ProcedureHistory)
                    .HasForeignKey(d => d.ProcedureStatusTypeID)
                    .HasConstraintName("FK_ProcedureHistory_ProcedureStatusTypes");
            });

            modelBuilder.Entity<ProcedureNextStatusDecisions>(entity =>
            {
                entity.HasKey(e => e.ProcedureNextStatusDecisionID);

                entity.Property(e => e.ProcedureNextStatusDecisionID)
                    .HasColumnName("ProcedureNextStatusDecisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentProcedureStatusTypeID).HasColumnName("CurrentProcedureStatusTypeID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NextProcedureStatusTypeID).HasColumnName("NextProcedureStatusTypeID");

                entity.Property(e => e.ProcedureActionTypeID).HasColumnName("ProcedureActionTypeID");

                entity.Property(e => e.ProcedureTypeID).HasColumnName("ProcedureTypeID");

                entity.HasOne(d => d.CurrentProcedureStatusType)
                    .WithMany(p => p.ProcedureNextStatusDecisionsCurrentProcedureStatusType)
                    .HasForeignKey(d => d.CurrentProcedureStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureNextStatusDecisions_ProcedureStatusTypes");

                entity.HasOne(d => d.NextProcedureStatusType)
                    .WithMany(p => p.ProcedureNextStatusDecisionsNextProcedureStatusType)
                    .HasForeignKey(d => d.NextProcedureStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcedureNextStatusDecisions_ProcedureStatusTypes1");

                entity.HasOne(d => d.ProcedureActionType)
                    .WithMany(p => p.ProcedureNextStatusDecisions)
                    .HasForeignKey(d => d.ProcedureActionTypeID)
                    .HasConstraintName("FK_ProcedureNextStatusDecisions_ProcedureActionTypes");

                entity.HasOne(d => d.ProcedureType)
                    .WithMany(p => p.ProcedureNextStatusDecisions)
                    .HasForeignKey(d => d.ProcedureTypeID)
                    .HasConstraintName("FK_ProcedureNextStatusDecisions_ProcedureTypes");
            });

            modelBuilder.Entity<ProcedureStatusTypes>(entity =>
            {
                entity.HasKey(e => e.ProcedureStatusTypeID);

                entity.Property(e => e.ProcedureStatusTypeID)
                    .HasColumnName("ProcedureStatusTypeID")
                    .HasComment("קוד סטטוס הליך");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.ProcedureStatusTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("תיאור סטטוס הליך");

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcedureTypes>(entity =>
            {
                entity.HasKey(e => e.ProcedureTypeId)
                    .HasName("PK_ProcessTypeId");

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedureTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStepID).HasColumnName("RequestStepID");

                entity.HasOne(d => d.RequestStep)
                    .WithMany(p => p.ProcedureTypes)
                    .HasForeignKey(d => d.RequestStepID)
                    .HasConstraintName("FK_ProcedureTypes_RequestSteps");
            });

            modelBuilder.Entity<Procedures>(entity =>
            {
                entity.HasKey(e => e.ProcessID)
                    .HasName("PK_Procedures_ProcessID");

                entity.Property(e => e.ProcessID)
                    .HasColumnName("ProcessID")
                    .HasComment("מפתח הליך")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("תאריך פתיחת הליך");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastProcedureActionID).HasColumnName("LastProcedureActionID");

                entity.Property(e => e.ProcedureComments).HasMaxLength(1000);

                entity.Property(e => e.ProcedureEndToDate)
                    .HasColumnType("datetime")
                    .HasComment("תאריך סוף הליך");

                entity.Property(e => e.ProcedureId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProcedureStartDate)
                    .HasColumnType("datetime")
                    .HasComment("תאריך תחילת הליך");

                entity.Property(e => e.ProcedureStatusTypeID)
                    .HasColumnName("ProcedureStatusTypeID")
                    .HasComment("קוד סטטוס הליך");

                entity.Property(e => e.ProcedureTypeID)
                    .HasColumnName("ProcedureTypeID")
                    .HasComment("סוג הליך");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.LastProcedureAction)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.LastProcedureActionID)
                    .HasConstraintName("FK_Procedures_ProcedureActionTypes");

                entity.HasOne(d => d.ProcedureStatusType)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.ProcedureStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_ProcedureStatusTypes");

                entity.HasOne(d => d.ProcedureType)
                    .WithMany(p => p.Procedures)
                    .HasForeignKey(d => d.ProcedureTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_ProcedureTypes");

                entity.HasOne(d => d.Process)
                    .WithOne(p => p.Procedures)
                    .HasForeignKey<Procedures>(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procedures_Processes");
            });

            modelBuilder.Entity<ProcessAppraisalPurposes>(entity =>
            {
                entity.HasKey(e => e.AppraisalPurposeID);

                entity.Property(e => e.AppraisalPurposeID)
                    .HasColumnName("AppraisalPurposeID")
                    .HasComment("מזהה חלופת שומה");

                entity.Property(e => e.AppraisalBusinessNeedTypesToPurposeTypesMapperID)
                    .HasColumnName("AppraisalBusinessNeedTypesToPurposeTypesMapperID")
                    .HasComment("מטרת שומה");

                entity.Property(e => e.AppraisalDateToAssign)
                    .HasColumnType("date")
                    .HasComment("מועד קובע");

                entity.Property(e => e.AppraisalPurposeComment)
                    .HasMaxLength(1000)
                    .HasComment("הערות לחלופת  שומה");

                entity.Property(e => e.AppraisalPurposeMaamTypeID).HasColumnName("AppraisalPurposeMaamTypeID");

                entity.Property(e => e.AppraisalPurposeMazamTypeID).HasColumnName("AppraisalPurposeMazamTypeID");

                entity.Property(e => e.AreaSizeInSquareMeter)
                    .HasColumnType("numeric(10, 2)")
                    .HasComment("שטח הקרקע במ\"ר");

                entity.Property(e => e.BuildAreaSizeInSquareMeter)
                    .HasColumnType("numeric(10, 2)")
                    .HasComment("שטח הקרקע במ\"ר");

                entity.Property(e => e.DevelopmentCost).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.DevelopmentCostCurrencyTypeID).HasColumnName("DevelopmentCostCurrencyTypeID");

                entity.Property(e => e.LandDevelopmentTypeID).HasColumnName("LandDevelopmentTypeID");

                entity.Property(e => e.ProcessID).HasColumnName("ProcessID");

                entity.Property(e => e.PropertyNatureTypeID).HasColumnName("PropertyNatureTypeID");

                entity.Property(e => e.PurposeValue).HasColumnType("numeric(22, 2)");

                entity.Property(e => e.PurposeValueCurrencyTypeID).HasColumnName("PurposeValueCurrencyTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AppraisalBusinessNeedTypesToPurposeTypesMapper)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.AppraisalBusinessNeedTypesToPurposeTypesMapperID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_AppraisalBusinessNeedTypesToPurposeTypesMapper");

                entity.HasOne(d => d.AppraisalPurposeMaamType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.AppraisalPurposeMaamTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_AppraisalPurposeMaamTypes");

                entity.HasOne(d => d.AppraisalPurposeMazamType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.AppraisalPurposeMazamTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_AppraisalPurposeMazamTypes");

                entity.HasOne(d => d.DevelopmentCostCurrencyType)
                    .WithMany(p => p.ProcessAppraisalPurposesDevelopmentCostCurrencyType)
                    .HasForeignKey(d => d.DevelopmentCostCurrencyTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_DevelopmentCostCurrency");

                entity.HasOne(d => d.LandDevelopmentType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.LandDevelopmentTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_LandDevelopmentTypes");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_Processes");

                entity.HasOne(d => d.PropertyNatureType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.PropertyNatureTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_PropertyNatureTypes");

                entity.HasOne(d => d.PropertySubType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.PropertySubTypeId)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_PropertySubTypes");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_PropertyTypes");

                entity.HasOne(d => d.ProtoType)
                    .WithMany(p => p.ProcessAppraisalPurposes)
                    .HasForeignKey(d => d.ProtoTypeId)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_Prototypes");

                entity.HasOne(d => d.PurposeValueCurrencyType)
                    .WithMany(p => p.ProcessAppraisalPurposesPurposeValueCurrencyType)
                    .HasForeignKey(d => d.PurposeValueCurrencyTypeID)
                    .HasConstraintName("FK_ProcessAppraisalPurposes_PurposeValueCurrency");
            });

            modelBuilder.Entity<ProcessAppraisalsPurposesToPropertyIdentitiesConnections>(entity =>
            {
                entity.HasKey(e => e.ProcessAppraisalPurposePropertyIdentityConnectionID);

                entity.Property(e => e.ProcessAppraisalPurposePropertyIdentityConnectionID)
                    .HasColumnName("ProcessAppraisalPurposePropertyIdentityConnectionID")
                    .HasComment("מפתח טבלת קשר חלופת שומה לנכס");

                entity.Property(e => e.ProcessAppraisalPurposeID)
                    .HasColumnName("ProcessAppraisalPurposeID")
                    .HasComment("מפתח חלופת שומה");

                entity.Property(e => e.PropertyIdentityID)
                    .HasColumnName("PropertyIdentityID")
                    .HasComment("מפתח נכס");

                entity.Property(e => e.RamiAreaSizeInSquareMeter).HasColumnType("numeric(12, 4)");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.ProcessAppraisalPurpose)
                    .WithMany(p => p.ProcessAppraisalsPurposesToPropertyIdentitiesConnections)
                    .HasForeignKey(d => d.ProcessAppraisalPurposeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessAppraisalsPurposesToPropertyIdentitiesConnections_ProcessAppraisalPurposes");

                entity.HasOne(d => d.PropertyIdentity)
                    .WithMany(p => p.ProcessAppraisalsPurposesToPropertyIdentitiesConnections)
                    .HasForeignKey(d => d.PropertyIdentityID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessAppraisalsPurposesToPropertyIdentitiesConnections_PropertyIdentities");
            });

            modelBuilder.Entity<ProcessContactRoleTypes>(entity =>
            {
                entity.HasKey(e => e.ProcessContactRoleTypeID);

                entity.Property(e => e.ProcessContactRoleTypeID).HasColumnName("ProcessContactRoleTypeID");

                entity.Property(e => e.ContactTypeID).HasColumnName("ContactTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProcessContactRoleTypeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.ProcessContactRoleTypes)
                    .HasForeignKey(d => d.ContactTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessContactRoleTypes_ContactTypes");
            });

            modelBuilder.Entity<ProcessProperties>(entity =>
            {
                entity.HasKey(e => e.PropertyID)
                    .HasName("PK_Properties");

                entity.Property(e => e.PropertyID).HasColumnName("PropertyID");

                entity.Property(e => e.Apartment).HasMaxLength(5);

                entity.Property(e => e.CityID).HasColumnName("CityID");

                entity.Property(e => e.CityNameNotVerified)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('.')");

                entity.Property(e => e.Comments).HasMaxLength(510);

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.Property(e => e.Entrance).HasMaxLength(5);

                entity.Property(e => e.Floor).HasMaxLength(5);

                entity.Property(e => e.HouseNumber).HasMaxLength(5);

                entity.Property(e => e.NumberOfRooms).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.ProcessID).HasColumnName("ProcessID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StreetID).HasColumnName("StreetID");

                entity.Property(e => e.StreetNameNotVerified).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.ProcessProperties)
                    .HasForeignKey(d => d.DistrictID)
                    .HasConstraintName("FK_ProcessProperties_Districts");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessProperties)
                    .HasForeignKey(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessProperties_Processes");
            });

            modelBuilder.Entity<ProcessStatusReasonTypes>(entity =>
            {
                entity.HasKey(e => e.ProcessStatusReasonTypeID);

                entity.Property(e => e.ProcessStatusReasonTypeID).HasColumnName("ProcessStatusReasonTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProcessStatusReasonTypeName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ProcessToContactConnectionTypes>(entity =>
            {
                entity.HasKey(e => e.ProcessToContactConnectionTypeID);

                entity.Property(e => e.ProcessToContactConnectionTypeID).HasColumnName("ProcessToContactConnectionTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProcessToContactConnectionTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ProcessTypes>(entity =>
            {
                entity.HasKey(e => e.ProcessTypeID);

                entity.Property(e => e.ProcessTypeID).HasColumnName("ProcessTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.ProcessTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Processes>(entity =>
            {
                entity.HasKey(e => e.ProcessID);

                entity.Property(e => e.ProcessID).HasColumnName("ProcessID");

                entity.Property(e => e.AppealOrganizationID).HasColumnName("AppealOrganizationID");

                entity.Property(e => e.AppraisalBusinessNeedTypeID)
                    .HasColumnName("AppraisalBusinessNeedTypeID")
                    .HasComment("מהות נכס לפניה ");

                entity.Property(e => e.AppraiserFees)
                    .HasColumnType("numeric(13, 0)")
                    .HasComment("שכר טרחה נדרש לשומה");

                entity.Property(e => e.ChildEntityID).HasColumnName("ChildEntityID");

                entity.Property(e => e.ClientFileNumber)
                    .HasMaxLength(30)
                    .HasComment("סימוכין לפניה");

                entity.Property(e => e.ClientOrderDate).HasColumnType("datetime");

                entity.Property(e => e.ClientOrderNumber).HasMaxLength(30);

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .HasComment("הערות לפניה");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("תאריך פתיחת הפניה");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DistrictAppealOrganizationContactID)
                    .HasColumnName("DistrictAppealOrganizationContactID")
                    .HasComment("גורם פונה - מחוז");

                entity.Property(e => e.EntityRelatedID).HasColumnName("EntityRelatedID");

                entity.Property(e => e.HandlingDistrictID).HasColumnName("HandlingDistrictID");

                entity.Property(e => e.ProcessDateEnd).HasColumnType("datetime");

                entity.Property(e => e.ProcessTypeId).HasColumnName("ProcessTypeID");

                entity.Property(e => e.RequestRecievedDate)
                    .HasColumnType("datetime")
                    .HasComment("תאריך קבלת הפניה");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StatusReasonTypeID)
                    .HasColumnName("StatusReasonTypeID")
                    .HasComment("קוד סיבת ביטול פניה");

                entity.Property(e => e.StatusUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AppealOrganization)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.AppealOrganizationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processes_AppealOrganizations");

                entity.HasOne(d => d.AppraisalBusinessNeedType)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.AppraisalBusinessNeedTypeID)
                    .HasConstraintName("FK_Processes_AppraisalBusinessNeedTypes");

                entity.HasOne(d => d.AppraiserType)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.AppraiserTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processes_ContactSubTypes");

                entity.HasOne(d => d.DistrictAppealOrganizationContact)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.DistrictAppealOrganizationContactID)
                    .HasConstraintName("FK_Processes_Companies");

                entity.HasOne(d => d.EntityRelated)
                    .WithMany(p => p.InverseEntityRelated)
                    .HasForeignKey(d => d.EntityRelatedID)
                    .HasConstraintName("FK_Processes_Processes");

                entity.HasOne(d => d.HandlingDistrict)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.HandlingDistrictID)
                    .HasConstraintName("FK_Processes_Districts");

                entity.HasOne(d => d.ProcessType)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.ProcessTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processes_ProcessTypes");

                entity.HasOne(d => d.StatusReasonType)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.StatusReasonTypeID)
                    .HasConstraintName("FK_Processes_ProcessStatusReasonTypes");
            });

            modelBuilder.Entity<ProcessesToContactsConnections>(entity =>
            {
                entity.HasKey(e => e.ProcessToContactsConnectionID);

                entity.Property(e => e.ProcessToContactsConnectionID)
                    .HasColumnName("ProcessToContactsConnectionID")
                    .HasComment("מפתח קשר בעל עניים לפניה");

                entity.Property(e => e.ContactID)
                    .HasColumnName("ContactID")
                    .HasComment("מפתח גורם (בעל עניין)");

                entity.Property(e => e.ProcessContactRoleTypeID).HasColumnName("ProcessContactRoleTypeID");

                entity.Property(e => e.ProcessID)
                    .HasColumnName("ProcessID")
                    .HasComment("מפתח פניה");

                entity.Property(e => e.ProcessToContactConnectionTypeID).HasColumnName("ProcessToContactConnectionTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ProcessesToContactsConnections)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessesToContactsConnections_Contacts");

                entity.HasOne(d => d.ProcessContactRoleType)
                    .WithMany(p => p.ProcessesToContactsConnections)
                    .HasForeignKey(d => d.ProcessContactRoleTypeID)
                    .HasConstraintName("FK_ProcessessToContactsConnections_ProcessContactRoleTypes");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessesToContactsConnections)
                    .HasForeignKey(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessesToContactsConnections_Processes");

                entity.HasOne(d => d.ProcessToContactConnectionType)
                    .WithMany(p => p.ProcessesToContactsConnections)
                    .HasForeignKey(d => d.ProcessToContactConnectionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessessToContactsConnections_ProcessToContactConnectionTypes");
            });

            modelBuilder.Entity<PropertiesGis>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.ToTable("PropertiesGIS");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.ForDate).HasColumnType("datetime");

                entity.Property(e => e.LeadingFeature)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Polygon).IsUnicode(false);

                entity.Property(e => e.SealAppraiser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppraisalPurposeType)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.AppraisalPurposeTypeId)
                    .HasConstraintName("FK_PropertiesGIS_AppraisalPurposeTypes");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK_PropertiesGIS_Blocks");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_PropertiesGIS_Cities");

                entity.HasOne(d => d.FromParcel)
                    .WithMany(p => p.PropertiesGisFromParcel)
                    .HasForeignKey(d => d.FromParcelId)
                    .HasConstraintName("FK_PropertiesGIS_Parcels_From");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_PropertiesGIS_Houses");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_PropertiesGIS_Plans");

                entity.HasOne(d => d.Plot)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.PlotId)
                    .HasConstraintName("FK_PropertiesGIS_Plots");

                entity.HasOne(d => d.ProcedureType)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.ProcedureTypeId)
                    .HasConstraintName("FK_PropertiesGIS_ProcedureTypes");

                entity.HasOne(d => d.PropertyNatureType)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.PropertyNatureTypeId)
                    .HasConstraintName("FK_PropertiesGIS_PropertyNatureTypes");

                entity.HasOne(d => d.Prototype)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.PrototypeId)
                    .HasConstraintName("FK_PropertiesGIS_Prototypes");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_PropertiesGIS_RequestsGIS");

                entity.HasOne(d => d.RequestStatusType)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.RequestStatusTypeId)
                    .HasConstraintName("FK_PropertiesGIS_RequestsStatusTypes");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.PropertiesGis)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK_PropertiesGIS_Streets");

                entity.HasOne(d => d.ToParcel)
                    .WithMany(p => p.PropertiesGisToParcel)
                    .HasForeignKey(d => d.ToParcelId)
                    .HasConstraintName("FK_PropertiesGIS_ParcelsTo");
            });

            modelBuilder.Entity<PropertiesTmp>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.ForDate).HasColumnType("datetime");

                entity.Property(e => e.LeadingFeature)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Polygon).IsUnicode(false);

                entity.Property(e => e.SealAppraiser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppraisalPurposeType)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.AppraisalPurposeTypeId)
                    .HasConstraintName("FK_PropertiesTmp_AppraisalPurposeTypes");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK_PropertiesTmp_Blocks");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_PropertiesTmp_Cities");

                entity.HasOne(d => d.FromParcel)
                    .WithMany(p => p.PropertiesTmpFromParcel)
                    .HasForeignKey(d => d.FromParcelId)
                    .HasConstraintName("FK_PropertiesTmp_Parcels_From");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK_PropertiesTmp_Houses");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_PropertiesTmp_Plans");

                entity.HasOne(d => d.Plot)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.PlotId)
                    .HasConstraintName("FK_PropertiesTmp_Plots");

                entity.HasOne(d => d.ProcedureType)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.ProcedureTypeId)
                    .HasConstraintName("FK_PropertiesTmp_ProcedureTypes");

                entity.HasOne(d => d.PropertyNatureType)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.PropertyNatureTypeId)
                    .HasConstraintName("FK_PropertiesTmp_PropertyNatureTypes");

                entity.HasOne(d => d.Prototype)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.PrototypeId)
                    .HasConstraintName("FK_PropertiesTmp_Prototypes");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_PropertiesTmp_RequestsGIS");

                entity.HasOne(d => d.RequestStatusType)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.RequestStatusTypeId)
                    .HasConstraintName("FK_PropertiesTmp_RequestsStatusTypes");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.PropertiesTmp)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK_PropertiesTmp_Streets");

                entity.HasOne(d => d.ToParcel)
                    .WithMany(p => p.PropertiesTmpToParcel)
                    .HasForeignKey(d => d.ToParcelId)
                    .HasConstraintName("FK_PropertiesTmp_Parcels_To");
            });

            modelBuilder.Entity<PropertyIdentities>(entity =>
            {
                entity.HasKey(e => e.PropertyIdentityID);

                entity.Property(e => e.PropertyIdentityID).HasColumnName("PropertyIdentityID");

                entity.Property(e => e.ClientFileNumberIsraelLandAuthority).HasMaxLength(510);

                entity.Property(e => e.CommercialArea).HasColumnType("numeric(12, 4)");

                entity.Property(e => e.FromParcelNumber).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.FromPlot).HasMaxLength(20);

                entity.Property(e => e.GrossArea).HasColumnType("numeric(12, 4)");

                entity.Property(e => e.PlanCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyID).HasColumnName("PropertyID");

                entity.Property(e => e.PropertyIdentityDescription)
                    .HasColumnName("propertyIdentityDescription")
                    .HasMaxLength(510);

                entity.Property(e => e.PropertyIdentityParcelStatusTypeID).HasColumnName("PropertyIdentityParcelStatusTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SubParcel)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ToParcelNumber).HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ToPlot).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyIdentities)
                    .HasForeignKey(d => d.PropertyID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyIdentities_Properties");

                entity.HasOne(d => d.PropertyIdentityParcelStatusType)
                    .WithMany(p => p.PropertyIdentities)
                    .HasForeignKey(d => d.PropertyIdentityParcelStatusTypeID)
                    .HasConstraintName("FK_PropertyIdentities_PropertyIdentityParcelStatusTypes");
            });

            modelBuilder.Entity<PropertyIdentityParcelStatusTypes>(entity =>
            {
                entity.HasKey(e => e.PropertyIdentityParcelStatusTypeID);

                entity.Property(e => e.PropertyIdentityParcelStatusTypeID)
                    .HasColumnName("PropertyIdentityParcelStatusTypeID")
                    .HasComment("קוד סוג חלקיות נכס");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PropertyIdentityParcelStatusTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("תיאור קוג סוג חלקיות נכס");
            });

            modelBuilder.Entity<PropertyNatureTypes>(entity =>
            {
                entity.HasKey(e => e.PropertyNatureTypeId);

                entity.Property(e => e.PropertyNatureTypeId).ValueGeneratedNever();

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyNatureTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertySubTypes>(entity =>
            {
                entity.HasKey(e => e.PropertySubTypeID);

                entity.Property(e => e.PropertySubTypeID).HasColumnName("PropertySubTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PropertySubTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PropertyTypeID).HasColumnName("PropertyTypeID");
            });

            modelBuilder.Entity<PropertyTypes>(entity =>
            {
                entity.HasKey(e => e.PropertyTypeId);

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PropertyTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Prototypes>(entity =>
            {
                entity.HasKey(e => e.PrototypeId)
                    .HasName("PK_PrototypeId");

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrototypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniversalCases)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PrototypesPropertyNatureTypesMapper>(entity =>
            {
                entity.HasKey(e => e.PrototypePropertyNatureTypeMapId);

                entity.HasOne(d => d.PropertyNatureType)
                    .WithMany(p => p.PrototypesPropertyNatureTypesMapper)
                    .HasForeignKey(d => d.PropertyNatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrototypesPropertyNatureTypesMapper_PropertyNatureTypes");

                entity.HasOne(d => d.Prototype)
                    .WithMany(p => p.PrototypesPropertyNatureTypesMapper)
                    .HasForeignKey(d => d.PrototypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrototypesPropertyNatureTypesMapper_Prototypes");
            });

            modelBuilder.Entity<PrototypesUniversalCasesAddition>(entity =>
            {
                entity.Property(e => e.PrototypesUniversalCasesAdditionID).HasColumnName("PrototypesUniversalCasesAdditionID");

                entity.Property(e => e.AppealOrganizationID).HasColumnName("AppealOrganizationID");

                entity.HasOne(d => d.AppealOrganization)
                    .WithMany(p => p.PrototypesUniversalCasesAddition)
                    .HasForeignKey(d => d.AppealOrganizationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrototypesUniversalCasesAddition_AppealOrganization");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.PrototypesUniversalCasesAddition)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrototypesUniversalCasesAddition_PropertyType");

                entity.HasOne(d => d.Prototype)
                    .WithMany(p => p.PrototypesUniversalCasesAddition)
                    .HasForeignKey(d => d.PrototypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrototypesUniversalCasesAddition_PrototypeId");
            });

            modelBuilder.Entity<RepositoryAppraiserAppoitmentTypes>(entity =>
            {
                entity.HasKey(e => e.RepositoryAppraiserAppoitmentTypeID);

                entity.Property(e => e.RepositoryAppraiserAppoitmentTypeID).HasColumnName("RepositoryAppraiserAppoitmentTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RepositoryAppraiserAppoitmentTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<RepositoryAppraisersWinningDetails>(entity =>
            {
                entity.Property(e => e.RepositoryAppraisersWinningDetailsID).HasColumnName("RepositoryAppraisersWinningDetailsID");

                entity.Property(e => e.Comments).HasMaxLength(100);

                entity.Property(e => e.ContactID).HasColumnName("ContactID");

                entity.Property(e => e.DistrictID).HasColumnName("DistrictID");

                entity.Property(e => e.RepositoryAppraisersWinningStatusID).HasColumnName("RepositoryAppraisersWinningStatusID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.RepositoryAppraisersWinningDetails)
                    .HasForeignKey(d => d.ContactID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepositoryAppraisersWinningDetails_Contacts");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.RepositoryAppraisersWinningDetails)
                    .HasForeignKey(d => d.DistrictID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepositoryAppraisersWinningDetails_Districts");

                entity.HasOne(d => d.RepositoryAppraisersWinningStatus)
                    .WithMany(p => p.RepositoryAppraisersWinningDetails)
                    .HasForeignKey(d => d.RepositoryAppraisersWinningStatusID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepositoryAppraisersWinningDetails_RepositoryAppraisersWinningStatus");
            });

            modelBuilder.Entity<RepositoryAppraisersWinningStatuses>(entity =>
            {
                entity.HasKey(e => e.RepositoryAppraisersWinningStatusID);

                entity.Property(e => e.RepositoryAppraisersWinningStatusID).HasColumnName("RepositoryAppraisersWinningStatusID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RepositoryAppraisersWinningStatusName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RequestActionTypes>(entity =>
            {
                entity.HasKey(e => e.RequestActionTypeID);

                entity.Property(e => e.RequestActionTypeID)
                    .HasColumnName("RequestActionTypeID")
                    .HasComment("");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon).HasMaxLength(100);

                entity.Property(e => e.RequestActionTypeImgUrl).HasMaxLength(500);

                entity.Property(e => e.RequestActionTypeImgUrlDisabled).HasMaxLength(500);

                entity.Property(e => e.RequestActionTypeImgUrlOnHover).HasMaxLength(500);

                entity.Property(e => e.RequestActionTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RequestActionTypesToRequestStatusTypesMapper>(entity =>
            {
                entity.Property(e => e.RequestActionTypesToRequestStatusTypesMapperID)
                    .HasColumnName("RequestActionTypesToRequestStatusTypesMapperID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestActionTypeID).HasColumnName("RequestActionTypeID");

                entity.Property(e => e.RequestStatusTypeID).HasColumnName("RequestStatusTypeID");

                entity.Property(e => e.RequestTypeID).HasColumnName("RequestTypeID");

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequestActionType)
                    .WithMany(p => p.RequestActionTypesToRequestStatusTypesMapper)
                    .HasForeignKey(d => d.RequestActionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestActionTypesToRequestStatusTypesMapper_RequestActionTypes");

                entity.HasOne(d => d.RequestStatusType)
                    .WithMany(p => p.RequestActionTypesToRequestStatusTypesMapper)
                    .HasForeignKey(d => d.RequestStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestActionTypesToRequestStatusTypesMapper_RequestsStatusTypes");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.RequestActionTypesToRequestStatusTypesMapper)
                    .HasForeignKey(d => d.RequestTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestActionTypesToRequestStatusTypesMapper_RequestTypes");
            });

            modelBuilder.Entity<RequestHistory>(entity =>
            {
                entity.Property(e => e.ActionDescription).HasMaxLength(100);

                entity.Property(e => e.AppraiserTypeID).HasColumnName("AppraiserTypeID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ProcessID).HasColumnName("ProcessID");

                entity.Property(e => e.RequestActionTypeID).HasColumnName("RequestActionTypeID");

                entity.Property(e => e.RequestComment).HasMaxLength(500);

                entity.Property(e => e.RequestStatusReasonTypeID).HasColumnName("RequestStatusReasonTypeID");

                entity.Property(e => e.RequestStatusTypeID).HasColumnName("RequestStatusTypeID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.AppraiserType)
                    .WithMany(p => p.RequestHistory)
                    .HasForeignKey(d => d.AppraiserTypeID)
                    .HasConstraintName("FK_RequestHistory_ContactSubTypes");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.RequestHistory)
                    .HasForeignKey(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestHistory_Requests");

                entity.HasOne(d => d.RequestActionType)
                    .WithMany(p => p.RequestHistory)
                    .HasForeignKey(d => d.RequestActionTypeID)
                    .HasConstraintName("FK_RequestHistory_RequestsActionTypes");

                entity.HasOne(d => d.RequestStatusReasonType)
                    .WithMany(p => p.RequestHistory)
                    .HasForeignKey(d => d.RequestStatusReasonTypeID)
                    .HasConstraintName("FK_RequestHistory_ProcessStatusReasonTypes");

                entity.HasOne(d => d.RequestStatusType)
                    .WithMany(p => p.RequestHistory)
                    .HasForeignKey(d => d.RequestStatusTypeID)
                    .HasConstraintName("FK_RequestHistory_RequestsStatusTypes");
            });

            modelBuilder.Entity<RequestNextStatusDecisions>(entity =>
            {
                entity.HasKey(e => e.RequestNextStatusDecisionID);

                entity.Property(e => e.RequestNextStatusDecisionID)
                    .HasColumnName("RequestNextStatusDecisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppraiserTypeID).HasColumnName("AppraiserTypeID");

                entity.Property(e => e.CurrentRequestStatusTypeID).HasColumnName("CurrentRequestStatusTypeID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NextRequestStatusTypeID).HasColumnName("NextRequestStatusTypeID");

                entity.Property(e => e.ProcedureStatusTypeID).HasColumnName("ProcedureStatusTypeID");

                entity.Property(e => e.RequestActionTypeID).HasColumnName("RequestActionTypeID");

                entity.Property(e => e.RequestStatusReasonTypeID).HasColumnName("RequestStatusReasonTypeID");

                entity.Property(e => e.RequestTypeID).HasColumnName("RequestTypeID");

                entity.HasOne(d => d.AppraiserType)
                    .WithMany(p => p.RequestNextStatusDecisions)
                    .HasForeignKey(d => d.AppraiserTypeID)
                    .HasConstraintName("FK_RequestNextStatusDecisions_ContactSubTypes");

                entity.HasOne(d => d.CurrentRequestStatusType)
                    .WithMany(p => p.RequestNextStatusDecisionsCurrentRequestStatusType)
                    .HasForeignKey(d => d.CurrentRequestStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Current_RequestNextStatusDecisions_RequestsStatusTypes");

                entity.HasOne(d => d.NextRequestStatusType)
                    .WithMany(p => p.RequestNextStatusDecisionsNextRequestStatusType)
                    .HasForeignKey(d => d.NextRequestStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Next_RequestNextStatusDecisions_RequestsStatusTypes");

                entity.HasOne(d => d.ProcedureStatusType)
                    .WithMany(p => p.RequestNextStatusDecisions)
                    .HasForeignKey(d => d.ProcedureStatusTypeID)
                    .HasConstraintName("FK_RequestNextStatusDecisions_ProcedureStatusTypes");

                entity.HasOne(d => d.RequestActionType)
                    .WithMany(p => p.RequestNextStatusDecisions)
                    .HasForeignKey(d => d.RequestActionTypeID)
                    .HasConstraintName("FK_RequestNextStatusDecisions_RequestActionTypes");

                entity.HasOne(d => d.RequestStatusReasonType)
                    .WithMany(p => p.RequestNextStatusDecisions)
                    .HasForeignKey(d => d.RequestStatusReasonTypeID)
                    .HasConstraintName("FK_RequestNextStatusDecisions_RequestStatusReasonTypes");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.RequestNextStatusDecisions)
                    .HasForeignKey(d => d.RequestTypeID)
                    .HasConstraintName("FK_RequestNextStatusDecisions_RequestTypes");
            });

            modelBuilder.Entity<RequestSteps>(entity =>
            {
                entity.HasKey(e => e.RequestStepID)
                    .HasName("PK_OrderTypes");

                entity.Property(e => e.RequestStepID).HasColumnName("RequestStepID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.RequestStepName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RequestTypes>(entity =>
            {
                entity.HasKey(e => e.RequestTypeID);

                entity.Property(e => e.RequestTypeID).HasColumnName("RequestTypeID");

                entity.Property(e => e.EnumDescription).HasMaxLength(30);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestStepID).HasColumnName("RequestStepID");

                entity.Property(e => e.RequestTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RequestStep)
                    .WithMany(p => p.RequestTypes)
                    .HasForeignKey(d => d.RequestStepID)
                    .HasConstraintName("FK_RequestTypes_RequestSteps");
            });

            modelBuilder.Entity<Requests>(entity =>
            {
                entity.HasKey(e => e.ProcessID)
                    .HasName("PK_Requests_ProcessID");

                entity.HasComment("גורם פותח  הפניה במרכז");

                entity.Property(e => e.ProcessID)
                    .HasColumnName("ProcessID")
                    .HasComment("מפתח פניה")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("תאריך פתיחת הפניה");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RequestFillingEndDate).HasColumnType("datetime");

                entity.Property(e => e.RequestId).ValueGeneratedOnAdd();

                entity.Property(e => e.RequestStatusTypeID)
                    .HasColumnName("RequestStatusTypeID")
                    .HasComment("קוד  סטטוס פניה");

                entity.Property(e => e.RequestStatusUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.RequestTypeID)
                    .HasColumnName("RequestTypeID")
                    .HasComment("קוד  סוג פניה");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(30);

                entity.HasOne(d => d.Process)
                    .WithOne(p => p.Requests)
                    .HasForeignKey<Requests>(d => d.ProcessID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_Processes");

                entity.HasOne(d => d.RequestStatusType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestStatusTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_RequestsStatusTypes");

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requests_RequestTypes");
            });

            modelBuilder.Entity<RequestsGis>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK_Requests");

                entity.ToTable("RequestsGIS");

                entity.HasIndex(e => e.RequestNumber)
                    .HasName("IX_Requests")
                    .IsUnique();
            });

            modelBuilder.Entity<RequestsStatusTypes>(entity =>
            {
                entity.HasKey(e => e.RequestStatusTypeId)
                    .HasName("PK_Status_Id");

                entity.Property(e => e.EnumDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStatusTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Streets>(entity =>
            {
                entity.HasKey(e => e.StreetId);

                entity.HasIndex(e => e.StreetName)
                    .HasName("IX_Streets");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Streets_Cities");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
