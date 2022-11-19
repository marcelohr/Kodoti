using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<DataCollection<AplicationUserDto>> GetAll(int page, int take);
    }

    public class UserService : IUserService
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AplicationDbContext context, IMapper mapper)
            => (this._context, this._mapper) = (context, mapper);

        public async Task<DataCollection<AplicationUserDto>> GetAll(int page, int take) =>
            _mapper.Map<DataCollection<AplicationUserDto>>(
                await _context.Users
                .OrderByDescending(x => x.Email)
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .AsQueryable()
                .PagedAsync(page, take)
            );
    }
}
