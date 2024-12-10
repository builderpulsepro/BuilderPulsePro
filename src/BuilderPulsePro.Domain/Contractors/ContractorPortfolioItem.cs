using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BuilderPulsePro.Contractors
{
    public class ContractorPortfolioItem : Entity<Guid>
    {
        public Guid ContractorProfileId { get; set; }
        public string Description { get; set; }
        public string BlobName { get; set; }
    }
}
