using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Subscriptions
{
    public class SubscriptionAppService : ApplicationService, ISubscriptionAppService
    {
        private readonly SubscriptionManager _subscriptionManager;

        public SubscriptionAppService(SubscriptionManager subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }

        public async Task CreateTrialSubscriptionAsync(Guid userId)
        {
            await _subscriptionManager.CreateTrialSubscriptionAsync(userId);
        }

        public async Task<bool> IsSubscriptionActiveAsync(Guid userId)
        {
            return await _subscriptionManager.IsSubscriptionActiveAsync(userId);
        }
    }
}
