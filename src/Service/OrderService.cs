using AutoMapper;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IOrderService
    {

    }

    public class OrderService : IOrderService
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(
            AplicationDbContext context,
            IMapper mapper
        )
        {
            this._context = context;
            this._mapper = mapper;
        }


    }
}
