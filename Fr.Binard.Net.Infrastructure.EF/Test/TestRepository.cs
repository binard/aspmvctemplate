using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Infrastructure.EF
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(IDbContextFactory contextFactory)
            : base(contextFactory)
        {
        }
    }
}
