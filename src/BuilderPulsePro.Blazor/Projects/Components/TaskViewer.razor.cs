using BuilderPulsePro.Projects;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Blazorise;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using BuilderPulsePro.Enums;
using Blazorise.DataGrid;
using System;
using System.Linq;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class TaskViewer
    {
        [Parameter]
        public ICollection<CreateUpdateProjectTaskDto> Tasks { get; set; }

        private EditTaskModal EditTaskModal { get; set; }

        private DataGrid<CreateUpdateProjectTaskDto> DataGrid { get; set; }

        private string ViewMode = "list";


        protected async Task AddTaskAsync(ProjectTaskType taskType, bool isAppointment = false)
        {
            var newProjectTask = new CreateUpdateProjectTaskDto()
            {
                Id = GuidGenerator.Create(),
                Title = taskType.ToString(),
                TaskType = taskType,
                IsAppointment = isAppointment,
            };

            await EditTaskModal.Show(newProjectTask);
        }

        public async Task ViewModeChanged(string viewMode)
        {
            ViewMode = viewMode;
            await InvokeAsync(StateHasChanged);
        }

        private async Task ProjectTaskSaved(CreateUpdateProjectTaskDto projectTaskDto)
        {
            if (!Tasks.Any(x => x.Id == projectTaskDto.Id))
            {
                Tasks.Add(projectTaskDto);
            }
            await DataGrid.Reload();
            await InvokeAsync(StateHasChanged);
        }

        private async Task RowClicked(DataGridRowMouseEventArgs<CreateUpdateProjectTaskDto> args)
        {
            await EditTaskModal.Show(args.Item);
        }

        private async Task Delete(CreateUpdateProjectTaskDto projectTaskDto)
        {
            Tasks.Remove(projectTaskDto);
            await DataGrid.Reload();
            await InvokeAsync(StateHasChanged);
        }
    }
}
