using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService) => this._clientService = clientService;

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
