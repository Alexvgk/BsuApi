using DbConect;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class ScheduleRepository : BaseRepository<Schedule>
    {
        public ScheduleRepository(MyDbContext dbContext) : base(dbContext) { }

        public async override Task<List<Schedule>> GetAllAsync()
        {
            return await _dbContext.Set<Schedule>().Include(s=>s.DayTimes).ToListAsync();
        }
    }
}
