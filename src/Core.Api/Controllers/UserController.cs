using Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;
using Service.Commons;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Model.DTOs;
using Service;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Admin)]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => this._userService = userService;
        [HttpGet]
        public async Task<ActionResult<DataCollection<AplicationUserDto>>> GetAll(int page, int take) =>
            await _userService.GetAll(page, take);
    }
}
