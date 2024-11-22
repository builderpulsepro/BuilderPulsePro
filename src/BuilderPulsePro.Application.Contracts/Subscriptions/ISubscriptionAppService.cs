using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Subscriptions
{
    public interface ISubscriptionAppService
    {
        Task CreateTrialSubscriptionAsync(Guid userId);

        Task<bool> IsSubscriptionActiveAsync(Guid userId);
    }
}
