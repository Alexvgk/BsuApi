using DbConect;
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
        private MyDbContext Context { get; set; }
        public BaseRepository(MyDbContext context)
        {
            Context = context;
        }

        public TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
                Context.Set<TDbModel>().Remove(toDelete);
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"No {typeof(TDbModel).Name} with id {id} found.");
            }
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                Context.Entry(toUpdate).CurrentValues.SetValues(model);
                Context.SaveChanges();
            }
            return toUpdate;
        }

        public TDbModel Get(Guid id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
        }
    }
}
