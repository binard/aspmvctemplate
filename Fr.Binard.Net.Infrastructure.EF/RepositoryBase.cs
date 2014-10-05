using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IIdentifiable
    {
        protected DbContext _dbContext;

        public RepositoryBase(IDbContextFactory contextFactory)
        {
            _dbContext = contextFactory.GetContext();
        }


        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().SingleOrDefault(x => x.ID == id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public virtual IQueryable<T> Get(Func<T, bool> filter)
        {
            return _dbContext.Set<T>().Where(filter).AsQueryable();
        }

        public virtual void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public virtual void Update(T item)
        {
            _dbContext.Set<T>().Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public virtual void Delete(int id)
        {
            T item = GetById(id);
            if (item != null)
                Delete(item);
        }
    }
}
