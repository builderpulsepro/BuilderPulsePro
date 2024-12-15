using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Enums;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Projects
{
    public class ProjectTask : Entity<Guid>
    {
        public string Title { get; set; }
        public ProjectTaskType TaskType { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAppointment { get; set; }

        public Guid ProjectId { get; set; }
        public Guid? ContractorProfileId { get; set; }

        public ICollection<ProjectTask> PrerequisiteTasks { get; set; }
        public ICollection<ProjectTask> DependentTasks { get; set; }
    }
}
