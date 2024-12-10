using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Global;

namespace BuilderPulsePro.Contractors
{
    public class CreateUpdateContractorProfileDto
    {
        [Required]
        [StringLength(ContractorProfileConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [StringLength(ContractorProfileConsts.MaxBusinessLicenseNumberLength)]
        public string? BusinessLicenseNumber { get; set; }

        [StringLength(ContractorProfileConsts.MaxIssuingStateLength)]
        public string? IssuingState { get; set; }

        [StringLength(ContractorProfileConsts.MaxIssuingAuthorityLength)]
        public string? IssuingAuthority { get; set; }

        //public bool IsVerified { get; set; }

        [Phone]
        [StringLength(BuilderPulseProGlobalConsts.MaxPhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(BuilderPulseProGlobalConsts.MaxEmailAddressLength)]
        public string? EmailAddress { get; set; }

        public ICollection<CreateUpdateContractorLocationDto> Locations { get; set; } = new List<CreateUpdateContractorLocationDto>();

        public ICollection<CreateUpdateContractorPortfolioItemDto> PortfolioItems { get; set; } = new List<CreateUpdateContractorPortfolioItemDto>();
    }
}
