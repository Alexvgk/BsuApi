using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
