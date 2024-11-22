using BuilderPulsePro.Events;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Threading;

namespace BuilderPulsePro.Identity
{
    public class CustomIdentityUserManager : IdentityUserManager
    {
        private readonly IDistributedEventBus _eventBus;

        public CustomIdentityUserManager(
            IdentityUserStore store,
            IIdentityRoleRepository roleRepository,
            IIdentityUserRepository userRepository,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<IdentityUserManager> logger,
            ICancellationTokenProvider cancellationTokenProvider,
            IOrganizationUnitRepository organizationUnitRepository,
            ISettingProvider settingProvider,
            IDistributedEventBus distributedEventBus,
            IIdentityLinkUserRepository identityLinkUserRepository,
            IDistributedCache<AbpDynamicClaimCacheItem> dynamicClaimCache,
            IDistributedEventBus eventBus)
            : base(store, roleRepository, userRepository, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, cancellationTokenProvider, organizationUnitRepository, settingProvider, distributedEventBus, identityLinkUserRepository, dynamicClaimCache)
        {
            _eventBus = eventBus;
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            var result = await base.CreateAsync(user);

            if (result.Succeeded)
            {
                await _eventBus.PublishAsync(new UserRegisteredEvent(user.Id));
            }

            return result;
        }
    }
}
