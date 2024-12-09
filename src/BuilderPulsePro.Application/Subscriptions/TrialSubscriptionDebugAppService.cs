using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace BuilderPulsePro.Subscriptions
{
    public class DebugTrialSubscriptionAppService : ApplicationService, IDebugTrialSubscriptionAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<UserSubscription, Guid> _subscriptionRepository;
        private readonly SubscriptionManager _subscriptionManager;

        public DebugTrialSubscriptionAppService(
            IRepository<IdentityUser, Guid> userRepository,
            IRepository<UserSubscription, Guid> subscriptionRepository,
            SubscriptionManager subscriptionManager)
        {
            _userRepository = userRepository;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionManager = subscriptionManager;
        }

        public async Task BackfillTrialSubscriptionsAsync()
        {
            // Get all users
            var users = await _userRepository.GetListAsync();

            foreach (var user in users)
            {
                // Check if the user already has a subscription
                var existingSubscription = await _subscriptionRepository.FirstOrDefaultAsync(s => s.UserId == user.Id);

                if (existingSubscription == null)
                {
                    // Create a trial subscription for the user
                    await _subscriptionManager.CreateTrialSubscriptionAsync(user.Id);
                }
            }
        }

        public async Task RenewTrialSubscriptionAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);

            var now = Clock.Now;

            var existingSubscription = await _subscriptionRepository.FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (existingSubscription != null && existingSubscription.IsTrial && existingSubscription.EndDate < now)
            {
                await _subscriptionManager.ResetTrialSubscriptionAsync(user.Id, 30);
            }
        }

        public async Task ExpireTrialSubscriptionAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);

            var now = Clock.Now;

            var existingSubscription = await _subscriptionRepository.FirstOrDefaultAsync(s => s.UserId == user.Id);

            if (existingSubscription != null && existingSubscription.IsTrial)
            {
                await _subscriptionManager.ResetTrialSubscriptionAsync(user.Id, -1);
            }
        }
    }
}
