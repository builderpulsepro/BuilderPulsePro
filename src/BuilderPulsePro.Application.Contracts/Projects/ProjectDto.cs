using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Enums;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Projects
{
    public class ProjectDto : FullAuditedEntityWithUserDto<Guid, IdentityUserDto>
    {
        public string Title { get; set; }
        public ProjectStatus Status { get; set; }

        public Guid? BuilderProfileID { get; set; }

        public Guid? ClientUserID { get; set; }

        public ICollection<ProjectTaskDto> ProjectTasks { get; set; }

        public ICollection<ProjectTaskDependencyDto> ProjectTaskDependencies { get; set; }
    }
}
