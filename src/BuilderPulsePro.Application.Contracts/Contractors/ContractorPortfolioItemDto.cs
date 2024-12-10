using System;

namespace BuilderPulsePro.Contractors
{
    public class ContractorPortfolioItemDto
    {
        public string Description { get; set; }
        public string BlobName { get; set; }

        public Guid? Id { get; set; }

        public Guid ContractorProfileId { get; set; }
    }
}
