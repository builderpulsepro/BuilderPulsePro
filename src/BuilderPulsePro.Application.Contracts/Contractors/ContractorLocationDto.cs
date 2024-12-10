using System;

namespace BuilderPulsePro.Contractors
{
    public class ContractorLocationDto
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid? Id { get; set; }

        public Guid ContractorProfileId { get; set; }
    }
}
