using Volo.Abp.Modularity;

namespace BuilderPulsePro;

[DependsOn(
    typeof(BuilderPulseProApplicationModule),
    typeof(BuilderPulseProDomainTestModule)
)]
public class BuilderPulseProApplicationTestModule : AbpModule
{

}
