using Volo.Abp.Modularity;

namespace BuilderPulsePro;

[DependsOn(
    typeof(BuilderPulseProDomainModule),
    typeof(BuilderPulseProTestBaseModule)
)]
public class BuilderPulseProDomainTestModule : AbpModule
{

}
