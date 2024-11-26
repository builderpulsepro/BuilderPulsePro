using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BuilderPulsePro.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BuilderPulseProDbContextFactory : IDesignTimeDbContextFactory<BuilderPulseProDbContext>
{
    public BuilderPulseProDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        BuilderPulseProEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<BuilderPulseProDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion, o =>
            {
                o.UseNetTopologySuite();
            });
        
        return new BuilderPulseProDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BuilderPulsePro.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true);


        return builder.Build();
    }
}
