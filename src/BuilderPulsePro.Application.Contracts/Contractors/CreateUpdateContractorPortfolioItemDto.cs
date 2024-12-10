using System;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.PortfolioItems;

namespace BuilderPulsePro.Contractors
{
    public class CreateUpdateContractorPortfolioItemDto
    {
        [StringLength(PortfolioItemConsts.MaxDescriptionLength)]
        public string? Description { get; set; }

        [Required]
        public string BlobName { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? Id { get; set; }
    }
}
