using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Builders
{
    public class BuilderProfile : FullAuditedAggregateRootWithUser<Guid, IdentityUser>
    {
        public string Name { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public string IssuingState { get; set; }
        public string IssuingAuthority { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<BuilderLocation> Locations { get; set; }
        public virtual ICollection<BuilderPortfolioItem> PortfolioItems { get; set; }
        public virtual ICollection<BuilderCollaborator> Collaborators { get; set; }
        public virtual ICollection<BuilderCollaboratorInvitation> CollaboratorInvitations { get; set; }

        //public BuilderProfile()
        //{
        //    Locations = new List<BuilderLocation>();
        //}
    }
}
