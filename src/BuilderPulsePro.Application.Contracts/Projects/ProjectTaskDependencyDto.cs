using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderPulsePro.Enums;

namespace BuilderPulsePro.Projects
{
    public class ProjectTaskDependencyDto
    {
        public Guid DependentTaskId { get; set; }
        public Guid PrerequisiteTaskId { get; set; }

        public Guid? Id { get; set; }
    }
}
