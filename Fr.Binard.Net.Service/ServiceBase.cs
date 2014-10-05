using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Service
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class, IIdentifiable
    {
        protected IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }


        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll().OrderBy(x => x.ID);
        }

        public virtual void Add(T item)
        {
            _repository.Add(item);
        }

        public virtual void Update(T item)
        {
            _repository.Update(item);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
