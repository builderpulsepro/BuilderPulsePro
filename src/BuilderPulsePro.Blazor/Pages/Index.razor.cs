using Blazorise;
using BuilderPulsePro.Blazor.Components.Modals;
using BuilderPulsePro.Enums;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Pages;

public partial class Index
{
    public Persona? CurrentPersona { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        if (CurrentUser.IsAuthenticated)
        {
            CurrentPersona = await userAppService.GetUserPersonaAsync();

            if (CurrentPersona != null && CurrentPersona == Persona.Builder)
            {
                Nav.NavigateTo("/BuilderDashboard", true);
            }
        }

        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }
}
