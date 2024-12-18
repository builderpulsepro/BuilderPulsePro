using System.Threading.Tasks;
using BuilderPulsePro.Contractors;
using BuilderPulsePro.Projects;
using Volo.Abp.Application.Dtos;

namespace BuilderPulsePro.Blazor.Contractors.Pages
{
    public partial class ContractorDashboard
    {
        public ContractorProfileDto Profile { get; set; }

        public PagedResultDto<ProjectDto> Projects { get; set; }

        private int currentPage = 1;
        private int pageSize = 5;
        private string sortField = nameof(ProjectDto.Title);
        private bool sortDescending;

        protected override async Task OnInitializedAsync()
        {
            Profile = await contractorAppService.GetCurrentUserContractorProfileAsync();

            if (Profile != null)
            {
                var input = new ProjectListFilterDto
                {
                    SkipCount = (currentPage - 1) * pageSize,
                    MaxResultCount = pageSize,
                    Sorting = sortDescending ? $"{sortField} DESC" : sortField,
                    ContractorId = Profile.Id
                };

                Projects = await projectAppService.GetProjectsByContractorAsync(input);
            }

            await base.OnInitializedAsync();
        }
    }
}
