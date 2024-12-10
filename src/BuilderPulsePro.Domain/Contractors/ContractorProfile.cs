using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Contractors
{
    public class ContractorProfile : FullAuditedAggregateRootWithUser<Guid, IdentityUser>
    {
        public string Name { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public string IssuingState { get; set; }
        public string IssuingAuthority { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<ContractorLocation> Locations { get; set; }
        public virtual ICollection<ContractorPortfolioItem> PortfolioItems { get; set; }
        public virtual ICollection<ContractorCollaborator> Collaborators { get; set; }
        public virtual ICollection<ContractorCollaboratorInvitation> CollaboratorInvitations { get; set; }

        //public BuilderProfile()
        //{
        //    Locations = new List<BuilderLocation>();
        //}
    }
}
