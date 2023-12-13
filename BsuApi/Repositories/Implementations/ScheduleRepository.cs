using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class ScheduleRepository : BaseRepository<Schedule>
    {
        public ScheduleRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
