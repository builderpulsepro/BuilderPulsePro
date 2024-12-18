using AutoMapper;
using Blazorise;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Projects;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace BuilderPulsePro.Blazor.Projects.Pages
{
    public partial class EditProject
    {
        [Parameter]
        public Guid ProjectId { get; set; }

        public CreateUpdateProjectDto ProjectDto { get; set; } = new CreateUpdateProjectDto();

        public Validations Validations { get; set; }

        private string selectedTab = "Details";

        protected override async Task OnParametersSetAsync()
        {
            var projectDto = await projectAppService.GetAsync(ProjectId);

            ProjectDto = ObjectMapper.Map<ProjectDto, CreateUpdateProjectDto>(projectDto);

            await base.OnParametersSetAsync();
        }

        protected async Task SaveAsync()
        {
            var projectDto = await projectAppService.UpdateAsync(ProjectId, ProjectDto);

            ProjectDto = ObjectMapper.Map<ProjectDto, CreateUpdateProjectDto>(projectDto);
        }

        protected void Back()
        {
            NavigationManager.NavigateTo("/BuilderDashboard");
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }
    }
}
