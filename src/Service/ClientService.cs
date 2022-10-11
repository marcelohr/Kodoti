using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IClientService
    {
        Task Create(ClientCreateDto model);
        Task<ClientDto> GetById(int id);
    }
    public class ClientService : IClientService
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public ClientService(
            AplicationDbContext context,
            IMapper mapper
            )
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ClientDto> GetById(int id) 
            => _mapper.Map<ClientDto>(await _context.Clients.SingleAsync(x => x.ClientId == id));

        public async Task Create(ClientCreateDto model)
        {
            Client entry = new Client { Name = model.Name };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
