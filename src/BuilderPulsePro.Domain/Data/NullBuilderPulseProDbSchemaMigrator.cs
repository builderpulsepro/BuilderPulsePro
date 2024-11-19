using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BuilderPulsePro.Data;

/* This is used if database provider does't define
 * IBuilderPulseProDbSchemaMigrator implementation.
 */
public class NullBuilderPulseProDbSchemaMigrator : IBuilderPulseProDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
