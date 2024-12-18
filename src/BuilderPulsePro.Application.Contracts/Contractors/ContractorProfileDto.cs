using System;
using System.Collections.Generic;
using BuilderPulsePro.Contractors;
using BuilderPulsePro.Enums;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Contractors
{
    public class ContractorProfileDto : FullAuditedEntityWithUserDto<Guid, IdentityUserDto>
    {
        public string Name { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public string IssuingState { get; set; }
        public string IssuingAuthority { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ProjectTaskType Specializations { get; set; }

        public ICollection<ContractorLocationDto> Locations { get; set; }
        public ICollection<ContractorPortfolioItemDto> PortfolioItems { get; set; }
    }
}
