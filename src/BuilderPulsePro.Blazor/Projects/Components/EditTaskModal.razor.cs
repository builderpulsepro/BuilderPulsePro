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

        public CreateUpdateProjectTaskDto ProjectTask { get; set; } = new CreateUpdateProjectTaskDto();

        private List<CreateUpdateProjectTaskDto> PrerequisiteTasks { get; set; }

        private List<Guid> PrerequisiteTaskIds { get; set; }

        public Modal Modal { get; set; }
        public Validations Validations { get; set; }

        private int AppointmentDuration { get; set; } = 1;

        public async Task Show(CreateUpdateProjectTaskDto task)
        {
            ProjectTask = task;
            //SelectedDependencyTaskIds = ProjectTask.DependencyTaskIds;
            if (ProjectTask.IsAppointment)
            {
                AppointmentDuration = ProjectTask.StartDate.HasValue && ProjectTask.EndDate.HasValue
                    ? (int)(ProjectTask.EndDate.Value - ProjectTask.StartDate.Value).TotalHours
                    : 1;
            }
            LoadPrerequisiteTasks();
            await Validations.ClearAll();
            await Modal.Show();
        }

        private void LoadPrerequisiteTasks()
        {
            PrerequisiteTasks = Tasks.Where(x => x.Id != ProjectTask.Id).ToList();
           // DependentTasks = Tasks.Where(x => x.Id != ProjectTask.Id && x.ProjectId == ProjectTask.ProjectId).ToList();
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
                if (ProjectTask.IsAppointment && ProjectTask.StartDate.HasValue)
                {
                    ProjectTask.EndDate = ProjectTask.StartDate.Value.AddHours(AppointmentDuration);
                }

                //ProjectTask.PrerequisiteTasks.Clear();
                

                //ProjectTask.PrerequisiteTaskIds.Clear();
                //ProjectTask.PrerequisiteTaskIds.AddRange(SelectedTaskIds);

                //ProjectTask.DependencyTaskIds.Clear();
                //ProjectTask.DependencyTaskIds.AddRange(SelectedDependencyTaskIds);

                await Close();

                if (Saved.HasDelegate)
                {
                    await Saved.InvokeAsync(ProjectTask);
                }
            }
        }

    }
}
