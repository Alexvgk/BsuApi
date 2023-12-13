using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        Task<TDbModel> GetByIdAsync(Guid id);
        Task<List<TDbModel>> GetAllAsync();
        Task AddAsync(TDbModel entity);
        Task UpdateAsync(TDbModel entity);
        Task DeleteAsync(Guid id);
    }
}
