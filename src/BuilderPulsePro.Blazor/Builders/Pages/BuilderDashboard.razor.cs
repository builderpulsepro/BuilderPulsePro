using BuilderPulsePro.Blazor.Projects.Components;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Projects;
using Humanizer;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BuilderPulsePro.Blazor.Builders.Pages
{
    public partial class BuilderDashboard
    {
        public BuilderProfileDto Profile { get; set; }

        public PagedResultDto<ProjectDto> Projects { get; set; }

        public CreateProjectModal CreateProjectModal { get; set; }

        private int currentPage = 1;
        private int pageSize = 5;
        private string sortField = nameof(ProjectDto.Title);
        private bool sortDescending;

        protected override async Task OnInitializedAsync()
        {
            Profile = await builderAppService.GetCurrentUserBuilderProfileAsync();

            if (Profile != null)
            {
                await LoadProjects();
            }

            await base.OnInitializedAsync();
        }

        private async Task LoadProjects()
        {
            var input = new ProjectListFilterDto
            {
                SkipCount = (currentPage - 1) * pageSize,
                MaxResultCount = pageSize,
                Sorting = sortDescending ? $"{sortField} DESC" : sortField,
                BuilderId = Profile.Id
            };

            Projects = await projectAppService.GetProjectsByBuilderAsync(input);
        }


        public async Task ProjectSaved()
        {
            await LoadProjects();
        }

        public async Task CreateProjectClicked()
        {
            await CreateProjectModal.Show();
        }
    }
}
