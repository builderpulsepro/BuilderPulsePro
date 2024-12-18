using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Enums;
using BuilderPulsePro.Global;
using BuilderPulsePro.Locations;

namespace BuilderPulsePro.Projects
{
    public class CreateUpdateProjectTaskDependencyDto
    {
        public Guid DependentTaskId { get; set; }
        public Guid PrerequisiteTaskId { get; set; }

        public Guid? Id { get; set; }
    }
}
