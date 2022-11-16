using Microsoft.AspNetCore.Mvc;
using Service.Commons;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Model.DTOs;

namespace Core.Api.Controllers
{
    [Authorize]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<DataCollection<AplicationUserDto>>> GetAll()
        {
            return Ok();
        }
    }
}
