using System;

namespace BuilderPulsePro.Builders
{
    public class BuilderPortfolioItemDto
    {
        public string Description { get; set; }
        public string BlobName { get; set; }

        public Guid? Id { get; set; }

        public Guid BuilderProfileId { get; set; }
    }
}
