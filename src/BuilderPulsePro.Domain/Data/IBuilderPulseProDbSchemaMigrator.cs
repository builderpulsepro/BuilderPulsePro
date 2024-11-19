using System.Threading.Tasks;

namespace BuilderPulsePro.Data;

public interface IBuilderPulseProDbSchemaMigrator
{
    Task MigrateAsync();
}
