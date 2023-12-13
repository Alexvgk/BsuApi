using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
