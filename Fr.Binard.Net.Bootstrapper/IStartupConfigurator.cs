using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Bootstrapper
{
    public interface IStartupConfigurator
    {
        void Configure(IKernel kernel);
    }
}
