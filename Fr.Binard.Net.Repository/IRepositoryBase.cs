using Fr.Binard.Net.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Repository
{
    public interface IRepositoryBase<T> where T : IIdentifiable
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Func<T, bool> filter);

        void Add(T item);
        void Update(T item);
        void Delete(T item);

        void Delete(int id);
       

    }
}
