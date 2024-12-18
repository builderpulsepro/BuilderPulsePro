using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Global;

namespace BuilderPulsePro.Builders
{
    public class CreateUpdateBuilderProfileDto
    {
        [Required]
        [StringLength(BuilderProfileConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [StringLength(BuilderProfileConsts.MaxBusinessLicenseNumberLength)]
        public string? BusinessLicenseNumber { get; set; }

        [StringLength(BuilderProfileConsts.MaxIssuingStateLength)]
        public string? IssuingState { get; set; }

        [StringLength(BuilderProfileConsts.MaxIssuingAuthorityLength)]
        public string? IssuingAuthority { get; set; }

        //public bool IsVerified { get; set; }

        [Phone]
        [StringLength(BuilderPulseProGlobalConsts.MaxPhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(BuilderPulseProGlobalConsts.MaxEmailAddressLength)]
        public string? EmailAddress { get; set; }

        public ICollection<CreateUpdateBuilderLocationDto> Locations { get; set; } = new List<CreateUpdateBuilderLocationDto>();

        public ICollection<CreateUpdateBuilderPortfolioItemDto> PortfolioItems { get; set; } = new List<CreateUpdateBuilderPortfolioItemDto>();
    }
}
