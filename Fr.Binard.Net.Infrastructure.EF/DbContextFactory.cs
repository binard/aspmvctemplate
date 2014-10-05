using Fr.Binard.Net.Utils.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContext GetContext()
        {
            var requestContext = HttpRequestSingleton<DefaultContext>.Instance;

            if(!requestContext.IsSet)
            {
                requestContext.Value = new DefaultContext();
            }

            return requestContext.Value;
        }
    }
}
