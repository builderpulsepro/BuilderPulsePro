using BuilderPulsePro.Locations;
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
        public string BusinessLicenseNumber { get; set; }
        public string IssuingState { get; set; }
        public string IssuingAuthority { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        
    }
}
