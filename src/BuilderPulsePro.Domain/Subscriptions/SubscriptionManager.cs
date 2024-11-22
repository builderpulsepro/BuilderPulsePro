using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace BuilderPulsePro.Subscriptions
{
    public class SubscriptionManager : DomainService
    {
        private readonly IRepository<UserSubscription, Guid> _subscriptionRepository;

        public SubscriptionManager(IRepository<UserSubscription, Guid> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task CreateTrialSubscriptionAsync(Guid userId)
        {
            var existingSubscription = await _subscriptionRepository.FirstOrDefaultAsync(x => x.UserId == userId);

            if (existingSubscription != null)
            {
                throw new BusinessException("User already has an active subscription.");
            }

            var subscription = new UserSubscription
            {
                UserId = userId,
                StartDate = Clock.Now,
                EndDate = Clock.Now.AddDays(30),
                IsTrial = true
            };

            await _subscriptionRepository.InsertAsync(subscription);
        }

        public async Task<bool> IsSubscriptionActiveAsync(Guid userId)
        {
            var subscription = await _subscriptionRepository.FirstOrDefaultAsync(x => x.UserId == userId);
            return subscription != null && subscription.EndDate >= Clock.Now;
        }

        public async Task RenewSubscriptionAsync(Guid userId, int renewalDays)
        {
            var subscription = await _subscriptionRepository.FirstOrDefaultAsync(x => x.UserId == userId);

            if (subscription == null)
            {
                throw new BusinessException("No active subscription found for the user.");
            }

            if (subscription.IsTrial)
            {
                throw new BusinessException("Trials cannot be renewed. Please subscribe to a paid plan.");
            }

            subscription.EndDate = subscription.EndDate.AddDays(renewalDays);
            subscription.IsTrial = false;

            await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task ResetTrialSubscriptionAsync(Guid userId, int renewalDays)
        {
            var subscription = await _subscriptionRepository.FirstOrDefaultAsync(x => x.UserId == userId);

            if (subscription == null)
            {
                throw new BusinessException("No active subscription found for the user.");
            }

            if (!subscription.IsTrial)
            {
                throw new BusinessException("Only valid for trial subscriptions.");
            }

            subscription.EndDate = Clock.Now.AddDays(renewalDays);

            await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task StartPaidSubscriptionAsync(Guid userId, int initialDays)
        {
            var subscription = await _subscriptionRepository.FirstOrDefaultAsync(x => x.UserId == userId);

            if (subscription == null)
            {
                // Create a new paid subscription
                subscription = new UserSubscription
                {
                    UserId = userId,
                    StartDate = Clock.Now,
                    EndDate = Clock.Now.AddDays(initialDays),
                    IsTrial = false
                };
                await _subscriptionRepository.InsertAsync(subscription);
            }
            else
            {
                // Transition from trial to paid
                if (subscription.IsTrial)
                {
                    subscription.StartDate = Clock.Now;
                    subscription.EndDate = Clock.Now.AddDays(initialDays);
                    subscription.IsTrial = false;
                    await _subscriptionRepository.UpdateAsync(subscription);
                }
                else
                {
                    throw new BusinessException("User already has an active paid subscription.");
                }
            }
        }
    }
}
