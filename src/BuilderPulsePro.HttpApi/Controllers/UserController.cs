using BuilderPulsePro.Enums;
using BuilderPulsePro.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPulsePro.Controllers
{
    [Route("api/user")]
    public class UserController : IUserAppService
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("persona")]
        public async Task<Persona> GetUserPersonaAsync()
        {
            return await _userAppService.GetUserPersonaAsync();
        }

        [HttpPost]
        [Route("persona")]
        public async Task SetUserPersonaAsync(Persona persona)
        {
            await _userAppService.SetUserPersonaAsync(persona);
        }

    }
}
