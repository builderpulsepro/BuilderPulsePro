using Blazorise;
using BuilderPulsePro.Projects;
using DeviceDetectorNET;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPulsePro.Blazor.Projects.Components
{
    public partial class ScheduleTaskModal
    {
        [Parameter]
        public EventCallback<CreateUpdateProjectTaskDto> Saved { get; set; }

        [Parameter]
        public ICollection<CreateUpdateProjectTaskDto> Tasks { get; set; }

        [Parameter]
        public CreateUpdateProjectDto Project { get; set; }

        private CreateUpdateProjectTaskDto NewTask { get; set; } = new CreateUpdateProjectTaskDto();

        private EditTaskComponent EditTaskComponent { get; set; }

        private DateTime StartDate { get; set; }

        public Modal Modal { get; set; }

        private string selectedTab = "available";

        public async Task Show(DateTime startDate)
        {
            if (Tasks.All(x => x.StartDate.HasValue))
            {
                selectedTab = "new";
            }

            NewTask.StartDate = startDate.Date;
            NewTask.EndDate = startDate.Date;
            NewTask.Id = GuidGenerator.Create();
            await EditTaskComponent.Init(NewTask);
            await Modal.Show();
        }

        private async Task Close()
        {
            await Modal.Hide();
        }

        private async void Save(CreateUpdateProjectTaskDto task)
        {
            if (selectedTab == "new")
            {
                var isValid = await EditTaskComponent.ValidateAll();
                if (isValid)
                {
                    await EditTaskComponent.Save();

                    NewTask.Id = GuidGenerator.Create();
                    Tasks.Add(NewTask);

                    await Close();

                    if (Saved.HasDelegate)
                    {
                        await Saved.InvokeAsync(task);
                    }
                }
            }
            else
            {
                await Close();

                if (Saved.HasDelegate)
                {
                    await Saved.InvokeAsync(task);
                }
            }
        }

        private async Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            await Task.CompletedTask;
        }

        private void SelectExistingTask(CreateUpdateProjectTaskDto task)
        {
            task.StartDate = StartDate;
            task.EndDate = StartDate;

            Save(task);
        }
    }
}
