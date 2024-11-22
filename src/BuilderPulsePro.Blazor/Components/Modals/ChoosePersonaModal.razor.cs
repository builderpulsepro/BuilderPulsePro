using Blazorise;
using BuilderPulsePro.Enums;
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && CurrentUser.IsAuthenticated)
            {
                var persona = await userAppService.GetUserPersonaAsync();
                if (persona == Persona.Undefined)
                {
                    await choosePersonaModal.Show();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task Close(Persona persona)
        {
            await userAppService.SetUserPersonaAsync(persona);

            await choosePersonaModal.Hide();
        }
    }
}
