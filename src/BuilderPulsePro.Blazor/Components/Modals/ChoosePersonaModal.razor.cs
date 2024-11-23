using Blazorise;
using BuilderPulsePro.Enums;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Components.Modals
{
    public partial class ChoosePersonaModal
    {
        private Modal choosePersonaModal;

        private Persona? CurrentPersona { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && CurrentUser.IsAuthenticated)
            {
                CurrentPersona = await userAppService.GetUserPersonaAsync();
                if (CurrentPersona.HasValue && CurrentPersona == Persona.Undefined)
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
