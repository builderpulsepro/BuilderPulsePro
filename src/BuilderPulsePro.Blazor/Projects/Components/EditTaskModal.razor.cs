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

        private List<CreateUpdateProjectTaskDto> OtherProjectTasks { get; set; }

        private List<Guid> PrerequisiteTaskIds { get; set; }
        private List<Guid> DependentTaskIds { get; set; }

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
            OtherProjectTasks = Tasks.Where(x => x.Id != ProjectTask.Id).ToList();

            PrerequisiteTaskIds = Project.ProjectTaskDependencies.Where(x => x.DependentTaskId == ProjectTask.Id!.Value).Select(x => x.PrerequisiteTaskId).ToList();
            DependentTaskIds = Project.ProjectTaskDependencies.Where(x => x.PrerequisiteTaskId == ProjectTask.Id!.Value).Select(x => x.DependentTaskId).ToList();
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

                Project.ProjectTaskDependencies.RemoveAll(x => x.PrerequisiteTaskId == ProjectTask.Id!.Value || x.DependentTaskId == ProjectTask.Id!.Value);

                if (PrerequisiteTaskIds != null)
                {
                    foreach (var prereq in PrerequisiteTaskIds)
                    {
                        Project.ProjectTaskDependencies.Add(new CreateUpdateProjectTaskDependencyDto
                        {
                            PrerequisiteTaskId = prereq,
                            DependentTaskId = ProjectTask.Id!.Value
                        });
                    }
                }
                if (DependentTaskIds != null)
                {
                    foreach (var dependency in DependentTaskIds)
                    {
                        Project.ProjectTaskDependencies.Add(new CreateUpdateProjectTaskDependencyDto
                        {
                            DependentTaskId = dependency,
                            PrerequisiteTaskId = ProjectTask.Id!.Value
                        });
                    }
                }

                await Close();

                if (Saved.HasDelegate)
                {
                    await Saved.InvokeAsync(ProjectTask);
                }
            }
        }

    }
}
