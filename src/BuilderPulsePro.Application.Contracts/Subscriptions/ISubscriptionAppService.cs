using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Subscriptions
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task CreateTrialSubscriptionAsync(Guid userId);

        Task<bool> IsSubscriptionActiveAsync(Guid userId);
    }
}
