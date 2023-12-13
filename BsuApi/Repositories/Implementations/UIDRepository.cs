using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class UIDRepository : BaseRepository<UID>
    {
        public UIDRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
