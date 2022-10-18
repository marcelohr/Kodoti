using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<AplicationUser> _userManager;
        public IdentityController(UserManager<AplicationUser> userManager) =>
            this._userManager = userManager;

        [HttpPost("register")]
        public async Task<IActionResult> Create(AplicationRegisterUserDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(
                new AplicationUser {
                    Email = model.Email,
                    UserName = model.Email
                },
                model.Password
            );

            if (!result.Succeeded) throw new Exception("No se pudo crear el usuario");
            return Ok();
        }
    }
}
