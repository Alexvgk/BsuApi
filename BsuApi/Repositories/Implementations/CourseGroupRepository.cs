using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class CourseGroupRepository : BaseRepository<CourseGroup>
    {
        public CourseGroupRepository(MyDbContext dbContext) : base(dbContext){
        }
    }
}
