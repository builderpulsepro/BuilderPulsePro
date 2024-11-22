using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Subscriptions
{
    public interface IDebugTrialSubscriptionAppService
    {
        Task BackfillTrialSubscriptionsAsync();
        Task RenewTrialSubscriptionAsync(Guid userId);
    }
}
