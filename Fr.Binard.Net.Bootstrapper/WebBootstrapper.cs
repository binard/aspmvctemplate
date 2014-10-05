using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Fr.Binard.Net.Common;
using Fr.Binard.Net.Common.Log;
using Fr.Binard.Net.Web.Core.Filters;

namespace Fr.Binard.Net.Bootstrapper
{
    public class WebBootstrapper : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Log4NetLogger.Configure();

            SetErrorFilter();
        }

        private void SetErrorFilter()
        {
        #if DEBUG
            GlobalFilters.Filters.Add(new ErrorExceptionFilter(ControllerBuilder.Current.GetControllerFactory(), 404));
        #else
            GlobalFilters.Filters.Add(new ErrorExceptionFilter(ControllerBuilder.Current.GetControllerFactory()));
        #endif
        }
    }
}
