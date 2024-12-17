using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Builders;
using BuilderPulsePro.Enums;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Projects
{
    public class Project : FullAuditedAggregateRootWithUser<Guid, IdentityUser>
    {
        public string Title { get; set; }
        public ProjectStatus Status { get; set; }

        public Guid? BuilderProfileID { get; set; }
        public Guid? ClientUserID { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }

        public virtual ICollection<ProjectTaskDependency> ProjectTaskDependencies { get; set; }
    }
}
