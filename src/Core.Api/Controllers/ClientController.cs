using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Admin)]
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService) => this._clientService = clientService;

        [HttpGet]
        public async Task<ActionResult<DataCollection<ClientDto>>> GetById(int page, int take)
            => await _clientService.GetAll(page, take);
        // /clients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetById(int id)
            => await _clientService.GetById(id);
        [HttpPost]
        public async Task<ActionResult> Create(ClientCreateDto model)
        {
            ClientDto result = await _clientService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.ClientId },
                result
            );
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ClientUpdateDto model)
        {
            await _clientService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _clientService.Remove(id);
            return NoContent();
        }
    }
}
