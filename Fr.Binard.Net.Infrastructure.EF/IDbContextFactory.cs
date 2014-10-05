using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }
}
