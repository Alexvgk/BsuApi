using DbConect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Implimentations;
using System.Runtime.CompilerServices;

namespace BsuApi.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext) { }

        public async override Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(u => u.Roles).Include(u => u.CorseGroup).ToListAsync();
        }

        public async override Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<User>()
                   .Include(u => u.Roles)
                   .Include(u=>u.CorseGroup)
                        .ThenInclude(c=>c.Schedules)
                   .Include(u=> u.CorseGroup)
                        .ThenInclude(c=>c.News)
                   .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
