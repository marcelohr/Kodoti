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

        public async Task<ActionResult> Create(ClientCreateDto model)
        {
            await _clientService.Create(model);
            return Ok();
        }
    }
}
