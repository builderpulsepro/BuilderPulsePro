using BuilderPulsePro.Builders;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Builders
{
    public class BuilderLocation : Entity<Guid>
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

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Guid BuilderProfileId { get; set; }

        [JsonIgnore]
        public Point Coordinates { get; set; }

    }
}
