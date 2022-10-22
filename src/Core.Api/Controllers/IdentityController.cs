using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public IdentityController(UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager, IConfiguration configuration)
            => (this._userManager, this._signInManager, this._configuration) = (userManager, signInManager, configuration);

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

        [HttpPost("login")]
        public async Task<IActionResult> Login(AplicationLoginUserDto model)
        {
            AplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (check.Succeeded)
            {
                return Ok(
                    GenerateToken(user)
                );
            }
            else
            {
                return BadRequest("Acceso no valido al sistema");
            }
        }

        private string GenerateToken(AplicationUser user)
        {
            var secretKey = _configuration.GetValue<string>("secretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
