using System;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Projects;
using Microsoft.AspNetCore.Components;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class CreateProjectModal
    {
        [Parameter]
        public EventCallback Saved { get; set; }

        [Parameter]
        public Guid? BuilderProfileId { get; set; }

        public CreateUpdateProjectDto ProjectDto { get; set; } = new CreateUpdateProjectDto();


        public Modal Modal { get; set; }

        public Validations Validations { get; set; }

        public async Task Show()
        {
            await Validations.ClearAll();
            ProjectDto = new CreateUpdateProjectDto();
            await Modal.Show();
        }

        private async Task Close()
        {
            await Modal.Hide();
        }

        private async void Save()
        {
            var isValid = await Validations.ValidateAll();
            if (isValid)
            {
                ProjectDto.BuilderProfileID = BuilderProfileId;

                await projectAppService.CreateAsync(ProjectDto);

                await Close();

                if (Saved.HasDelegate)
                {
                    await Saved.InvokeAsync();
                }

                ProjectDto = new CreateUpdateProjectDto();
            }
        }
    }
}
