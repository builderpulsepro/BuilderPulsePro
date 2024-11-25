using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Builders
{
    public class BuilderProfile : FullAuditedAggregateRootWithUser<Guid, IdentityUser>
    {
        public string Name { get; set; }
    }
}
