using BuilderPulsePro.Localization;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro;

/* Inherit your application services from this class.
 */
public abstract class BuilderPulseProAppService : ApplicationService
{
    protected BuilderPulseProAppService()
    {
        LocalizationResource = typeof(BuilderPulseProResource);
    }
}
