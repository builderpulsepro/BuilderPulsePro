using Blazorise;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Components.Modals
{
    public partial class ChoosePersonaModal
    {
        private Modal choosePersonaModal;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && CurrentUser.IsAuthenticated)
            {
                await choosePersonaModal.Show();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task Close()
        {
            await choosePersonaModal.Hide();
        }
    }
}
