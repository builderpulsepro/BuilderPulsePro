using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Subscriptions
{
    public class CreateSubscriptionDto
    {
        public Guid UserId { get; set; }
        public bool IsTrial { get; set; }
    }
}
