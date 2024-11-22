using BuilderPulsePro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BuilderPulsePro.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<Persona> GetUserPersonaAsync();
        Task SetUserPersonaAsync(Persona persona);
    }
}
