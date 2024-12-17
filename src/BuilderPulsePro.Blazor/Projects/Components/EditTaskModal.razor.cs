using Blazorise;
using BuilderPulsePro.Projects;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class EditTaskModal
    {
        [Parameter]
        public EventCallback<CreateUpdateProjectTaskDto> Saved { get; set; }

        [Parameter]
        public ICollection<CreateUpdateProjectTaskDto> Tasks { get; set; }

        [Parameter]
        public CreateUpdateProjectDto Project { get; set; }

        public CreateUpdateProjectTaskDto ProjectTask { get; set; } = new CreateUpdateProjectTaskDto();

        public Modal Modal { get; set; }
        
        private EditTaskComponent EditTaskComponent { get; set; }

        private int AppointmentDuration { get; set; } = 1;

        public async Task Show(CreateUpdateProjectTaskDto task)
        {
            ProjectTask = task;
            await EditTaskComponent.Init(ProjectTask);
            await Modal.Show();
        }

        private async Task Close()
        {
            await Modal.Hide();
        }

        private async void Save()
        {
            var isValid = await EditTaskComponent.ValidateAll();
            if (isValid)
            {
                await EditTaskComponent.Save();

                await Close();

                if (Saved.HasDelegate)
                {
                    await Saved.InvokeAsync(ProjectTask);
                }
            }
        }

    }
}
