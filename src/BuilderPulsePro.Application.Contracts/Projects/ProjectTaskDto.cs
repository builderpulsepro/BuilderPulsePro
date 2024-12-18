using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Enums;

namespace BuilderPulsePro.Projects
{
    public class ProjectTaskDto
    {
        public string Title { get; set; }
        public ProjectTaskType TaskType { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAppointment { get; set; }

        public Guid? ContractorProfileId { get; set; }

        public Guid? Id { get; set; }

    }
}
