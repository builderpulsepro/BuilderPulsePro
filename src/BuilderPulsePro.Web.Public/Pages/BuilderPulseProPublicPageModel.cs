using BuilderPulsePro.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BuilderPulsePro.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class BuilderPulseProPublicPageModel : AbpPageModel
{
    protected BuilderPulseProPublicPageModel()
    {
        LocalizationResourceType = typeof(BuilderPulseProResource);
    }
}
