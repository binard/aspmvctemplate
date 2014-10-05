using Fr.Binard.Net.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Service
{
    public interface IServiceBase<T> where T : IIdentifiable
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        void Add(T item);

        void Update(T item);

        void Delete(int id);

    }
}
