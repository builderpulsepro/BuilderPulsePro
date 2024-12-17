using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using BuilderPulsePro.Projects;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class EditTaskComponent
    {
        public Validations Validations { get; set; }

        public CreateUpdateProjectTaskDto ProjectTask { get; set; } = new CreateUpdateProjectTaskDto();

        [Parameter]
        public CreateUpdateProjectDto Project { get; set; }
        [Parameter]
        public ICollection<CreateUpdateProjectTaskDto> Tasks { get; set; }
        [Parameter]
        public bool AllowTaskTypeSelection { get; set; }

        private int AppointmentDuration { get; set; } = 1;

        private List<CreateUpdateProjectTaskDto> OtherProjectTasks { get; set; }

        private List<Guid> PrerequisiteTaskIds { get; set; }
        private List<Guid> DependentTaskIds { get; set; }

        public async Task ClearValidations()
        {
            await Validations.ClearAll();
        }

        public async Task<bool> ValidateAll()
        {
            return await Validations.ValidateAll();
        }

        public async Task Init(CreateUpdateProjectTaskDto projectTask)
        {
            ProjectTask = projectTask;
            if (ProjectTask.IsAppointment)
            {
                AppointmentDuration = ProjectTask.StartDate.HasValue && ProjectTask.EndDate.HasValue
                    ? (int)(ProjectTask.EndDate.Value - ProjectTask.StartDate.Value).TotalHours
                    : 1;
            }
            LoadPrerequisiteTasks();
            await Validations.ClearAll();
        }

        private void LoadPrerequisiteTasks()
        {
            OtherProjectTasks = Tasks.Where(x => x.Id != ProjectTask.Id).ToList();

            PrerequisiteTaskIds = Project.ProjectTaskDependencies.Where(x => x.DependentTaskId == ProjectTask.Id!.Value).Select(x => x.PrerequisiteTaskId).ToList();
            DependentTaskIds = Project.ProjectTaskDependencies.Where(x => x.PrerequisiteTaskId == ProjectTask.Id!.Value).Select(x => x.DependentTaskId).ToList();
        }

        public async Task Save()
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
            }
        }
    }
}
