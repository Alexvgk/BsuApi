using DbConect;
using Microsoft.EntityFrameworkCore;
using Model.Base;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implimentations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        protected readonly private MyDbContext _dbContext;
        public BaseRepository(MyDbContext context)
        {
            _dbContext = context;
        }



        public virtual async Task<TDbModel> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TDbModel>().FindAsync(id);
        }

        public virtual async Task<List<TDbModel>> GetAllAsync()
        {
            return await _dbContext.Set<TDbModel>().ToListAsync();
        }

        public virtual async Task AddAsync(TDbModel entity)
        {
            await _dbContext.Set<TDbModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TDbModel entity)
        {
            _dbContext.Set<TDbModel>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var deleted = _dbContext.Set<TDbModel>().FindAsync(id).GetAwaiter();
            _dbContext.Set<TDbModel>().Remove(deleted.GetResult());
            await _dbContext.SaveChangesAsync();
        }
    }
}
