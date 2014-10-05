using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Service
{
    public class TestService : ServiceBase<Test>, ITestService
    {
        private ITestRepository _testRepository;

        public TestService(ITestRepository repository)
            : base(repository)
        {
            _testRepository = repository;
        }
    }
}
