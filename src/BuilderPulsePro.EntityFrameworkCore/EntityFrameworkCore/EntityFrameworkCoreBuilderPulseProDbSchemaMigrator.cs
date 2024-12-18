using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BuilderPulsePro.Data;
using Volo.Abp.DependencyInjection;
using MySqlConnector;

namespace BuilderPulsePro.EntityFrameworkCore;

public class EntityFrameworkCoreBuilderPulseProDbSchemaMigrator
    : IBuilderPulseProDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBuilderPulseProDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BuilderPulseProDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        try
        {
            await _serviceProvider
                .GetRequiredService<BuilderPulseProDbContext>()
                .Database
                .MigrateAsync();
        }
        catch (MySqlException e)
        {
            var dbContext = _serviceProvider.GetRequiredService<BuilderPulseProDbContext>();
            var connectionString = dbContext.Database.GetDbConnection().ConnectionString;

            // Redact sensitive information
            var safeConnectionString = new MySqlConnectionStringBuilder(connectionString)
            {
                Password = "******" // Mask the password
            }.ToString();

            // Log the detailed error message
            Console.WriteLine("Unable to connect to the database.");
            Console.WriteLine($"Connection String: {safeConnectionString}");
            Console.WriteLine($"Exception: {e.Message}");

            // Optionally rethrow the exception or handle it further
            throw new Exception($"Database migration failed. Connection String: {safeConnectionString}", e);
        }
    }
}
