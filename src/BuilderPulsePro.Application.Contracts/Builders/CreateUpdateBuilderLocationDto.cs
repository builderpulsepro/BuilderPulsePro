using System;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.Global;
using BuilderPulsePro.Locations;

namespace BuilderPulsePro.Builders
{
    public class CreateUpdateBuilderLocationDto
    {
        [StringLength(LocationConsts.MaxNameLength)]
        public string? Name { get; set; }
        [StringLength(BuilderPulseProGlobalConsts.MaxEmailAddressLength)]
        public string? EmailAddress { get; set; }
        [StringLength(BuilderPulseProGlobalConsts.MaxPhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(LocationConsts.MaxStreetLength)]
        public string Street1 { get; set; }
        [StringLength(LocationConsts.MaxStreetLength)]
        public string? Street2 { get; set; }
        [Required]
        [StringLength(LocationConsts.MaxCityLength)]
        public string City { get; set; }
        [Required]
        [StringLength(LocationConsts.MaxStateLength)]
        public string State { get; set; }
        [Required]
        [StringLength(LocationConsts.MaxZipLength)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(LocationConsts.MaxCountryLength)]
        public string Country { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }

        public Guid? Id { get; set; }
    }
}
