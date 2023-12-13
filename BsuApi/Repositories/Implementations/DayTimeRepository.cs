using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class DayTimeRepository : BaseRepository<DayTime>
    {
        public DayTimeRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
