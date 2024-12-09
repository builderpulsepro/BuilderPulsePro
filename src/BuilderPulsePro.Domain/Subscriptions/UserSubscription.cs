using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BuilderPulsePro.Subscriptions
{
    public class UserSubscription : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTrial { get; set; }
    }
}
