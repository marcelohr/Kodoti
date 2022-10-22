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
    public interface IClientService
    {
        Task<DataCollection<ClientDto>> GetAll(int page, int take);
        Task<ClientDto> GetById(int id);
        Task<ClientDto> Create(ClientCreateDto model);
        Task Update(int id, ClientUpdateDto model);
        Task Remove(int id);
    }
    public class ClientService : IClientService
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public ClientService(AplicationDbContext context, IMapper mapper)
            => (this._context, this._mapper) = (context, mapper);

        public async Task<DataCollection<ClientDto>> GetAll(int page, int take)
            => _mapper.Map<DataCollection<ClientDto>>(
                    await _context.Clients.OrderByDescending(x => x.ClientId)
                                        .AsQueryable()
                                        .PagedAsync(page, take)
                );

        public async Task<ClientDto> GetById(int id)
            => _mapper.Map<ClientDto>(await _context.Clients.SingleAsync(x => x.ClientId == id));

        public async Task<ClientDto> Create(ClientCreateDto model)
        {
            Client entry = new Client { Name = model.Name };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClientDto>(entry);
        }

        public async Task Update(int id, ClientUpdateDto model)
        {
            Client entry = await _context.Clients.SingleAsync(x => x.ClientId == id);
            entry.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _context.Remove(new Client
            {
                ClientId = id
            });
            await _context.SaveChangesAsync();
        }
    }
}
