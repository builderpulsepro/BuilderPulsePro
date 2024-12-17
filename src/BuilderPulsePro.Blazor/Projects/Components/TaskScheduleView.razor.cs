using Blazorise.DataGrid;
using BuilderPulsePro.Projects;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Threading;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class TaskScheduleView
    {
        [Parameter]
        public ICollection<CreateUpdateProjectTaskDto> Tasks { get; set; }

        [Parameter]
        public CreateUpdateProjectDto Project { get; set; }

        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        public View CurrentView { get; set; } = View.Month;

        public IEnumerable<AppointmentData> TaskAppointments { get; set; }

        public EditTaskModal EditTaskModal { get; set; }

        protected override Task OnParametersSetAsync()
        {
            if (Tasks != null)
            {
                LoadTaskAppointments();
            }

            return base.OnParametersSetAsync();
        }

        private void LoadTaskAppointments()
        {
            TaskAppointments = Tasks.Where(x => x.StartDate.HasValue).Select(task =>
                new AppointmentData
                {
                    Id = task.Id!.Value,
                    Subject = task.Title,
                    StartTime = task.StartDate!.Value,
                    EndTime = task.IsAppointment ? task.EndDate!.Value : task.EndDate!.Value.AddHours(24),
                    IsAllDay = !task.IsAppointment
                }
            );
        }

        public void OnResizeStop(ResizeEventArgs<AppointmentData> args)
        {
            var appointmentData = args.Data;
            var projectTask = Tasks.First(x => x.Id == appointmentData.Id);
            projectTask.StartDate = appointmentData.IsAllDay ? appointmentData.StartTime.Date : appointmentData.StartTime;
            projectTask.EndDate = appointmentData.IsAllDay ? appointmentData.EndTime.AddDays(-1).Date : appointmentData.EndTime;

            if (!projectTask.IsAppointment)
            {
                UpdateDependentTaskDates(projectTask);
            }

            LoadTaskAppointments();
        }

        public void OnDragStop(DragEventArgs<AppointmentData> args)
        {
            var appointmentData = args.Data;
            var projectTask = Tasks.First(x => x.Id == appointmentData.Id);
            projectTask.StartDate = appointmentData.IsAllDay ? appointmentData.StartTime.Date : appointmentData.StartTime;
            projectTask.EndDate = appointmentData.IsAllDay ? appointmentData.EndTime.AddDays(-1).Date : appointmentData.EndTime;

            if (!projectTask.IsAppointment)
            {
                UpdateDependentTaskDates(projectTask);
            }

            LoadTaskAppointments();
        }

        public async Task HandlePopupOpen(PopupOpenEventArgs<AppointmentData> args)
        {
            args.Cancel = true;
            await EditTaskModal.Show(Tasks.First(x => x.Id!.Value == args.Data.Id));
        }

        private async Task ProjectTaskSaved(CreateUpdateProjectTaskDto projectTaskDto)
        {
            LoadTaskAppointments();
        }

        private void UpdateDependentTaskDates(CreateUpdateProjectTaskDto updatedTask)
        {
            var taskDependencies = Project.ProjectTaskDependencies.Where(x => x.PrerequisiteTaskId == updatedTask.Id!.Value);

            if (taskDependencies.Count() > 0)
            {
                foreach (var task in taskDependencies)
                {
                    var dependentTask = Tasks.First(x => x.Id!.Value == task.DependentTaskId);
                    if (dependentTask.StartDate.HasValue && dependentTask.EndDate.HasValue && dependentTask.StartDate <= updatedTask.EndDate)
                    {
                        int totalDays = CalculateWorkingDays(dependentTask.StartDate.Value, dependentTask.EndDate.Value) - 1;
                        dependentTask.StartDate = MoveToNextWorkingDay(updatedTask.EndDate.Value.AddDays(1));
                        dependentTask.EndDate = AddWorkingDays(dependentTask.StartDate.Value, totalDays);

                        UpdateDependentTaskDates(dependentTask);
                    }
                }
            }
        }

        private int CalculateWorkingDays(DateTime start, DateTime end)
        {
            int workingDays = 0;
            DateTime current = start;

            while (current <= end)
            {
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
                current = current.AddDays(1);
            }

            return workingDays;
        }

        private DateTime MoveToNextWorkingDay(DateTime date)
        {
            while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            return date;
        }

        private DateTime AddWorkingDays(DateTime startDate, int totalDays)
        {
            int addedDays = 0;
            DateTime current = startDate;

            while (addedDays < totalDays)
            {
                current = current.AddDays(1);
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    addedDays++;
                }
            }

            return current;
        }

    }

    public class AppointmentData
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
    }
}
