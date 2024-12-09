using System;
using System.ComponentModel.DataAnnotations;
using BuilderPulsePro.PortfolioItems;

namespace BuilderPulsePro.Builders
{
    public class CreateUpdateBuilderPortfolioItemDto
    {
        [StringLength(PortfolioItemConsts.MaxDescriptionLength)]
        public string? Description { get; set; }

        [Required]
        public string BlobName { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? Id { get; set; }
    }
}
