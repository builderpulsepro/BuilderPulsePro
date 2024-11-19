using Volo.Abp.Modularity;

namespace BuilderPulsePro;

/* Inherit from this class for your domain layer tests. */
public abstract class BuilderPulseProDomainTestBase<TStartupModule> : BuilderPulseProTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
