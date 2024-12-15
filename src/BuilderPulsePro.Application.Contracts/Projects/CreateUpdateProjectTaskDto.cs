using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Enums;
using BuilderPulsePro.Global;
using BuilderPulsePro.Locations;

namespace BuilderPulsePro.Projects
{
    public class CreateUpdateProjectTaskDto
    {
        [Required]
        [StringLength(ProjectTaskConsts.MaxTitleLength)]
        public string Title { get; set; }

        public ProjectTaskType TaskType { get; set; }
        public ProjectTaskStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAppointment { get; set; }

        public Guid? ContractorProfileId { get; set; }

        public Guid? Id { get; set; }

        public ICollection<CreateUpdateProjectTaskDto> PrerequisiteTasks { get; set; }

        public ICollection<CreateUpdateProjectTaskDto> DependentTasks { get; set; }
    }
}
