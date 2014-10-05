using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fr.Binard.Net.Web.Core.Mappers;
using Ninject;

namespace Fr.Binard.Net.Bootstrapper
{
    public class MapperStartupConfigurator : IStartupConfigurator
    {
        public void Configure(IKernel kernel)
        {
            ConfigureMappers(kernel);
            InitMapping(kernel);
        }

        private void ConfigureMappers(IKernel kernel)
        {
            kernel.Bind<IMapper>().To<DomainViewModelMapper>();
        }

        private void InitMapping(IKernel kernel)
        {
            var mappers = kernel.GetAll<IMapper>();
            foreach (var mapper in mappers)
            {
                mapper.Map();
            }
        }
    }
}
