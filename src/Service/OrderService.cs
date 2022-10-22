using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        Task<DataCollection<OrderDto>> GetAll(int page, int take);
        Task<OrderDto> GetById(int id);
        Task<OrderDto> Create(OrderCreateDto model);
    }

    public class OrderService : IOrderService
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly decimal IvaRate = 0.18m;
        public OrderService(AplicationDbContext context, IMapper mapper)
            => (this._context, this._mapper) = (context, mapper);

        public async Task<DataCollection<OrderDto>> GetAll(int page, int take) =>
            _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                    .AsQueryable()
                    .PagedAsync(page, take)
            );

        public async Task<OrderDto> GetById(int id) =>
            _mapper.Map<OrderDto>(
                await _context.Orders
                    .Include(x => x.Client)
                    .Include(x => x.Items)
                        .ThenInclude(x => x.Product)
                    .SingleAsync(x => x.OrderId == id)
            );

        public async Task<OrderDto> Create(OrderCreateDto model)
        {
            Order entry = _mapper.Map<Order>(model);
            PrepareDetail(entry.Items);
            PrepareHeader(entry);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDto>(
                await GetById(entry.OrderId)
            );
        }

        private void PrepareDetail(IEnumerable<OrderDetail> items)
        {
            foreach(var item in items)
            {
                item.Total = item.UnitPrice * item.Quantity;
                item.Iva = item.Total * IvaRate;
                item.Subtotal = item.Total - IvaRate;
            }
        }

        private void PrepareHeader(Order order)
        {
            order.Subtotal = order.Items.Sum(x => x.Subtotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }
    }
}
