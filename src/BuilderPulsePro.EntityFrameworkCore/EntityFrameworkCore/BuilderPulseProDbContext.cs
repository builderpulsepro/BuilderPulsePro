using BuilderPulsePro.Builders;
using BuilderPulsePro.Global;
using BuilderPulsePro.Locations;
using BuilderPulsePro.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Gdpr;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;

namespace BuilderPulsePro.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ConnectionStringName("Default")]
public class BuilderPulseProDbContext :
    AbpDbContext<BuilderPulseProDbContext>,
    IIdentityProDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DbSet<BuilderProfile> BuilderProfiles { get; set; }
    public DbSet<BuilderLocation> Locations { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    #endregion

    public BuilderPulseProDbContext(DbContextOptions<BuilderPulseProDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureLanguageManagement();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureGdpr();
        builder.ConfigureCmsKit();
        builder.ConfigureCmsKitPro();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BuilderPulseProConsts.DbTablePrefix + "YourEntities", BuilderPulseProConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<UserSubscription>(userSubscription =>
        {
            userSubscription.ToTable(BuilderPulseProConsts.DbTablePrefix + "UserSubscriptions");
            userSubscription.ConfigureByConvention();
            userSubscription.Property(x => x.UserId).IsRequired();
        });

        builder.Entity<BuilderProfile>(builder =>
        {
            builder.ToTable(BuilderPulseProConsts.DbTablePrefix + "BuilderProfiles");
            builder.ConfigureByConvention();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(BuilderProfileConsts.MaxNameLength);
            builder.Property(x => x.BusinessLicenseNumber).IsRequired(false).HasMaxLength(BuilderProfileConsts.MaxBusinessLicenseNumberLength);
            builder.Property(x => x.IssuingState).IsRequired(false).HasMaxLength(BuilderProfileConsts.MaxIssuingStateLength);
            builder.Property(x => x.IssuingAuthority).IsRequired(false).HasMaxLength(BuilderProfileConsts.MaxIssuingAuthorityLength);
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(BuilderPulseProGlobalConsts.MaxPhoneNumberLength);
            builder.Property(x => x.EmailAddress).IsRequired(false).HasMaxLength(BuilderPulseProGlobalConsts.MaxEmailAddressLength);
        });

        builder.Entity<BuilderLocation>(location =>
        {
            location.ToTable(BuilderPulseProConsts.DbTablePrefix + "BuilderLocations");
            location.ConfigureByConvention();
            location.HasKey(x => x.Id);
            location.Property(x => x.Name).IsRequired(false).HasMaxLength(LocationConsts.MaxNameLength);
            location.Property(x => x.EmailAddress).IsRequired(false).HasMaxLength(BuilderPulseProGlobalConsts.MaxEmailAddressLength);
            location.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(BuilderPulseProGlobalConsts.MaxPhoneNumberLength);
            location.Property(x => x.Street1).IsRequired().HasMaxLength(LocationConsts.MaxStreetLength);
            location.Property(x => x.Street2).IsRequired(false).HasMaxLength(LocationConsts.MaxStreetLength);
            location.Property(x => x.City).IsRequired().HasMaxLength(LocationConsts.MaxCityLength);
            location.Property(x => x.State).IsRequired().HasMaxLength(LocationConsts.MaxStateLength);
            location.Property(x => x.Country).IsRequired().HasMaxLength(LocationConsts.MaxCountryLength);
            location.Property(x => x.Coordinates).IsRequired().HasColumnType("geometry").HasSpatialReferenceSystem(4326);
            location.HasIndex(x => x.Coordinates).HasDatabaseName("IX_Location_Coordinates").IsSpatial();

            location.HasOne<BuilderProfile>()
                .WithMany(x => x.Locations)
                .HasForeignKey(x => x.BuilderProfileId)
                .IsRequired();
        });
    }
}
