using BuilderPulsePro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BuilderPulsePro.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BuilderPulseProController : AbpControllerBase
{
    protected BuilderPulseProController()
    {
        LocalizationResource = typeof(BuilderPulseProResource);
    }
}
