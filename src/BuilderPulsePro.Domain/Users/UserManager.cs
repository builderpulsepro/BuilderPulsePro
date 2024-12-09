using BuilderPulsePro.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Timing;
using Volo.Abp;
using Volo.Abp.Identity;
using BuilderPulsePro.Enums;
using Volo.Abp.Data;

namespace BuilderPulsePro.Users
{
    public class UserManager : DomainService
    {
        private readonly IRepository<IdentityUser, Guid> _identityUserRepository;

        public UserManager(IRepository<IdentityUser, Guid> identityUserRepository)
        {
            _identityUserRepository = identityUserRepository;
        }

        public async Task<Persona> GetUserPersona(Guid userId)
        {
            var user = await _identityUserRepository.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new BusinessException("Unable to get persona. User not found.");
            }

            return user.GetProperty<Persona>("Persona");
        }

        public async Task SetUserPersona(Guid userId, Persona persona)
        {
            var user = await _identityUserRepository.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new BusinessException("Unable to set persona. User not found.");
            }

            user.SetProperty("Persona", persona);

            await _identityUserRepository.UpdateAsync(user);
        }
    }
}
