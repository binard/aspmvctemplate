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
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextFactory _contextFactory;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Begin()
        {
            _contextFactory.GetContext();
        }

        public void Commit()
        {
            _contextFactory.GetContext().SaveChanges();
        }

        public void Rollback()
        {
            
        }

        public void Dispose()
        {
            if (_contextFactory.GetContext() != null)
            {
                _contextFactory.GetContext().Dispose();
            }
        }
    }
}
