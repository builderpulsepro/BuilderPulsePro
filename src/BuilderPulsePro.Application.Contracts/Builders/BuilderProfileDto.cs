using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Builders
{
    public class BuilderProfileDto : FullAuditedEntityWithUserDto<Guid, IdentityUserDto>
    {
        public string Name { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public string IssuingState { get; set; }
        public string IssuingAuthority { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<BuilderLocationDto> Locations { get; set; }
    }
}
