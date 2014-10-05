using Fr.Binard.Net.Common.Log;
using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fr.Binard.Net.Bootstrapper
{
    public class DefaultStartupConfigurator : IStartupConfigurator
    {
        public void Configure(IKernel kernel)
        {
            UnitOfWorkFactory.GetDefault = () => kernel.Get<IUnitOfWork>();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(kernel));
            Logger.Get = () => kernel.Get<ILogger>();
        }
    }
}
