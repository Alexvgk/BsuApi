using DbConect;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext) { }

        public async override Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().Include(u => u.Roles).Include(u => u.CorseGroup).ToListAsync();
        }
    }
}
