using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Builders
{
    public class BuilderCollaborator : Entity<Guid>
    {
        public Guid BuilderProfileId { get; set; }
        public Guid UserId { get; set; }
    }
}
