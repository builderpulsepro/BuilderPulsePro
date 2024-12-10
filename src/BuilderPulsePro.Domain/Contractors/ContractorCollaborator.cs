using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Contractors
{
    public class ContractorCollaborator : Entity<Guid>
    {
        public Guid ContractorProfileId { get; set; }
        public Guid UserId { get; set; }
    }
}
