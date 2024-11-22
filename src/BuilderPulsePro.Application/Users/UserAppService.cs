using BuilderPulsePro.Enums;
using BuilderPulsePro.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly UserManager _userManager;

        public UserAppService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<Persona> GetUserPersonaAsync()
        {
            return await _userManager.GetUserPersona(CurrentUser.Id!.Value);
        }

        public async Task SetUserPersonaAsync(Persona persona)
        {
            await _userManager.SetUserPersona(CurrentUser.Id!.Value, persona);
        }
    }
}
