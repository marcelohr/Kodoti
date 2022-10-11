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
    }
    public class ClientService : IClientService
    {
        private readonly AplicationDbContext _context;
        public ClientService(AplicationDbContext context) => this._context = context;

        public async Task Create(ClientCreateDto model)
        {
            Client entry = new Client { Name = model.Name };
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
        }
    }
}
