using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles = RoleHelper.Admin + "," + RoleHelper.Seller)]
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) => this._orderService = orderService;

        [HttpGet]
        public async Task<ActionResult<DataCollection<OrderDto>>> GetAll(int page, int take) => 
            await _orderService.GetAll(page, take);

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id) => await _orderService.GetById(id);

        [HttpPost]
        public async Task<ActionResult> Create(OrderCreateDto model)
        {
            var result = await _orderService.Create(model);
            return CreatedAtAction(
                "GetById",
                new { id = result.OrderId },
                result
            );
        }
    }
}
