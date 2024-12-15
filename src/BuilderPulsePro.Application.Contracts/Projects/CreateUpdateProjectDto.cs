using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Enums;
using BuilderPulsePro.Global;

namespace BuilderPulsePro.Projects
{
    public class CreateUpdateProjectDto
    {
        [Required]
        [StringLength(ProjectConsts.MaxTitleLength)]
        public string Title { get; set; } = string.Empty;

        public ProjectStatus Status { get; set; }

        public Guid? BuilderProfileID { get; set; }

        public Guid? ClientUserID { get; set; }

        public ICollection<CreateUpdateProjectTaskDto> ProjectTasks { get; set; } = new List<CreateUpdateProjectTaskDto>();
    }
}
