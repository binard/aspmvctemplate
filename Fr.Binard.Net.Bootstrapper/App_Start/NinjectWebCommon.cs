using Fr.Binard.Net.Common.Log;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Fr.Binard.Net.Bootstrapper.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Fr.Binard.Net.Bootstrapper.App_Start.NinjectWebCommon), "Stop")]

namespace Fr.Binard.Net.Bootstrapper.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using System.IO;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IStartupConfigurator>().To<DefaultStartupConfigurator>();
            kernel.Bind<IStartupConfigurator>().To<MapperStartupConfigurator>();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            kernel.Bind(x => x.FromAssembliesInPath(path).SelectAllClasses().BindDefaultInterface());
            //kernel.Bind(x => x.FromAssembliesInPath(path).SelectAllClasses().InheritedFrom<IStartupConfigurator>().BindToSelf());

            BindSpecific(kernel);
            StartConfigurators(kernel);
        }

        private static void BindSpecific(IKernel kernel)
        {
            kernel.Bind<ILogger>().To<Log4NetLogger>();
        }
        
        private static void StartConfigurators(IKernel kernel)
        {            
            var configurators = kernel.GetAll<IStartupConfigurator>();
            foreach(var configurator in configurators)
            {
                configurator.Configure(kernel);
            }
        }
    }
}
