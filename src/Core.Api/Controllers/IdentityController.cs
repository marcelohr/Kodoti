using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
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
            AplicationUser user = new AplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, RoleHelper.Seller);

            if (!result.Succeeded) return BadRequest("No se pudo crear el usuario.");
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AplicationLoginUserDto model)
        {
            AplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (check.Succeeded)
                {
                    return Ok(
                        await GenerateToken(user)
                    );
                }
            }
            
            return BadRequest("Acceso no valido al sistema");
        }

        [Authorize]
        [HttpGet("refresh_token")]
        public async Task<IActionResult> Refresh()
        {
            string userId = User.Claims.Where(x => x.Equals(ClaimTypes.NameIdentifier)).Single().Value;
            AplicationUser user = await _userManager.FindByIdAsync(userId);
            return Ok(
                await GenerateToken(user)
            );
        }

        private async Task<string> GenerateToken(AplicationUser user)
        {
            var secretKey = _configuration.GetValue<string>("secretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
