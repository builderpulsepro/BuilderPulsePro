using BuilderPulsePro.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace BuilderPulsePro.Subscriptions
{
    public class UserRegisteredEventHandler : IDistributedEventHandler<UserRegisteredEvent>, ITransientDependency
    {
        private readonly SubscriptionManager _subscriptionManager;

        public UserRegisteredEventHandler(SubscriptionManager subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }

        public async Task HandleEventAsync(UserRegisteredEvent eventData)
        {
            // Create a trial subscription for the newly registered user
            await _subscriptionManager.CreateTrialSubscriptionAsync(eventData.UserId);
        }
    }
}
