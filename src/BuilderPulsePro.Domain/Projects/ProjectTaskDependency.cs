using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Projects
{
    public class ProjectTaskDependency : Entity<Guid>
    {
        public Guid DependentTaskId { get; set; }
        public Guid PrerequisiteTaskId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
