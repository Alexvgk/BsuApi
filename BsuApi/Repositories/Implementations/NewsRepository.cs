using DbConect;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Repositories.Implementations
{
    public class NewsRepository : BaseRepository<News>
    {
        public NewsRepository(MyDbContext context) : base(context)
        {
        }

    }
}
