using Blazorise;
using BuilderPulsePro.Enums;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Components.Modals
{
    public partial class ChoosePersonaModal
    {
        private Modal choosePersonaModal;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task Close(Persona persona)
        {
            await userAppService.SetUserPersonaAsync(persona);
            await choosePersonaModal.Hide();

            if (persona == Persona.Builder)
            {
                Nav.NavigateTo("/BuilderDashboard", true);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await choosePersonaModal.Show();
            }
        }
    }
}
