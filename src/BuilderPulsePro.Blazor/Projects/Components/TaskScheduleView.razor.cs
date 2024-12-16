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

        public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        public View CurrentView { get; set; } = View.Month;

        public IEnumerable<AppointmentData> TaskAppointments { get; set; }

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
            LoadTaskAppointments();
        }

        public void OnDragStop(DragEventArgs<AppointmentData> args)
        {
            var appointmentData = args.Data;
            var projectTask = Tasks.First(x => x.Id == appointmentData.Id);
            projectTask.StartDate = appointmentData.IsAllDay ? appointmentData.StartTime.Date : appointmentData.StartTime;
            projectTask.EndDate = appointmentData.IsAllDay ? appointmentData.EndTime.AddDays(-1).Date : appointmentData.EndTime;
            LoadTaskAppointments();
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
