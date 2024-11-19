﻿using Microsoft.Extensions.Localization;
using BuilderPulsePro.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BuilderPulsePro;

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
