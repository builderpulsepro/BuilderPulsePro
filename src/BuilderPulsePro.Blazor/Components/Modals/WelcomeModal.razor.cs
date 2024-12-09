using Blazorise;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Components.Modals
{
    public partial class WelcomeModal
    {
        private Modal welcomeModal;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !CurrentUser.IsAuthenticated)
            {
                await welcomeModal.Show();
            }
            await base.OnAfterRenderAsync(firstRender);
        }


        private async Task Closing(ModalClosingEventArgs args)
        {
            args.Cancel = true;
            await Task.CompletedTask;
        }
    }
}
