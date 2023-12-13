using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class LessonFormRepository : BaseRepository<LessonForm>
    {
        public LessonFormRepository(MyDbContext dbContext) : base(dbContext) { }
    }
}
