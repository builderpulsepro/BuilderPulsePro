using BuilderPulsePro.Builders;
using Humanizer;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Builders.Pages
{
    public partial class BuilderDashboard
    {
        public BuilderProfileDto Profile { get; set; }


        protected override async Task OnInitializedAsync()
        {

            Profile = await builderAppService.GetCurrentUserBuilderProfileAsync();



            await base.OnInitializedAsync();

        }

    }
}
