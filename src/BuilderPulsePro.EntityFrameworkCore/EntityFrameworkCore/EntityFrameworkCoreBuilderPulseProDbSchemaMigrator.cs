using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BuilderPulsePro.Data;
using Volo.Abp.DependencyInjection;

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

        await _serviceProvider
            .GetRequiredService<BuilderPulseProDbContext>()
            .Database
            .MigrateAsync();
    }
}
