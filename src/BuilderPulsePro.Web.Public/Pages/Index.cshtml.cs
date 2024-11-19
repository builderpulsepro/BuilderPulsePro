using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace BuilderPulsePro.Web.Public.Pages;

public class IndexModel : BuilderPulseProPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
