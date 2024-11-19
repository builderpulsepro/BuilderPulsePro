using BuilderPulsePro.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BuilderPulsePro.Blazor;

public abstract class BuilderPulseProComponentBase : AbpComponentBase
{
    protected BuilderPulseProComponentBase()
    {
        LocalizationResource = typeof(BuilderPulseProResource);
    }
}
