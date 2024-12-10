using System.Threading.Tasks;
using BuilderPulsePro.Contractors;

namespace BuilderPulsePro.Blazor.Contractors.Pages
{
    public partial class ContractorDashboard
    {
        public ContractorProfileDto Profile { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Profile = await contractorAppService.GetCurrentUserContractorProfileAsync();

            await base.OnInitializedAsync();
        }
    }
}
