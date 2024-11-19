using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using BuilderPulsePro.Localization;

namespace BuilderPulsePro.Web.Public;

[Dependency(ReplaceServices = true)]
public class BuilderPulseProBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BuilderPulseProResource> _localizer;

    public BuilderPulseProBrandingProvider(IStringLocalizer<BuilderPulseProResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
