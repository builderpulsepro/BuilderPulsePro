using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Builders
{
    public class BuilderProfileDto : FullAuditedEntityWithUserDto<Guid, IdentityUserDto>
    {
        public string Name { get; set; }
    }
}
