using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Repository
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
        void Dispose();
    }
}
