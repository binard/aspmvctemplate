using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fr.Binard.Net.Web.Core.Controllers
{
    public abstract class ErrorControllerBase : Controller
    {
        private readonly IControllerFactory _controllerFactory;

        protected ErrorControllerBase(IControllerFactory controllerFactory)
        {
            _controllerFactory = controllerFactory;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            // Eviter de boucler si exception dans ErrorController
            if (GetType() != typeof (ErrorController))
            {
                HandleHttpException(HttpContext, 404);
            }
        }

        public ActionResult HandleHttpException(HttpContextBase httpContext, int statusCode)
        {
            var errorController = _controllerFactory.CreateController(httpContext.Request.RequestContext, "Error");
            var errorRoute = new RouteData();
            switch (statusCode)
            {
                case 404:
                    errorRoute.Values.Add("controller", "Error");
                    errorRoute.Values.Add("action", "Http404");
                    break;
                case 500:
                    errorRoute.Values.Add("controller", "Error");
                    errorRoute.Values.Add("action", "Http500");
                    break;
                default:
                    errorRoute.Values.Add("controller", "Error");
                    errorRoute.Values.Add("action", "Generic");
                    errorRoute.Values.Add("statusCode", statusCode);
                    break;
            }

            Debug.Assert(httpContext.Request.Url != null, "httpContext.Request.Url != null");
            errorRoute.Values.Add("url", httpContext.Request.Url.OriginalString);
            errorController.Execute(new RequestContext(httpContext, errorRoute));

            return new EmptyResult();
        }


    }
}
