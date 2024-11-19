using Volo.Abp.Modularity;

namespace BuilderPulsePro;

public abstract class BuilderPulseProApplicationTestBase<TStartupModule> : BuilderPulseProTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
