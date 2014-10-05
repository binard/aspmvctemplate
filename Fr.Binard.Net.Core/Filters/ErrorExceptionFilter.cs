using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Fr.Binard.Net.Web.Core.Controllers;

namespace Fr.Binard.Net.Web.Core.Filters
{
    public class ErrorExceptionFilter : IExceptionFilter
    {
        private readonly IControllerFactory _controllerFactory;
        private readonly int _statusCode;
        public ErrorExceptionFilter(IControllerFactory controllerFactory)
            : this(controllerFactory, 0)
        {
        }

        public ErrorExceptionFilter(IControllerFactory controllerFactory, HttpStatusCodeResult prototype)
            : this(controllerFactory, prototype.StatusCode)
        {
        }

        public ErrorExceptionFilter(IControllerFactory controllerFactory, int statusCode)
        {
            _controllerFactory = controllerFactory;
            _statusCode = statusCode;
        }

        public void OnException(ExceptionContext filterContext)
        {

            if (filterContext.Controller.GetType() == typeof(ErrorController))
            {
                return; // Eviter une boucle infinie si il y a une exception dans le controller d'erreur
            }

            int currentStatusCode = GetHttpCode(filterContext);
            if ((currentStatusCode == _statusCode || _statusCode == 0) && !filterContext.ExceptionHandled)
            {
                filterContext.ExceptionHandled = true;
                HandleExceptionWithViewResult(filterContext.Controller.ControllerContext, currentStatusCode);
            }
        }

        private int GetHttpCode(ExceptionContext filterContext)
        {
            var httpException = filterContext.Exception as HttpException;
            if (httpException == null)
                return 500; // returns 500 si ce n'est pas une HttpException

            return httpException.GetHttpCode();
        }


        private void HandleExceptionWithViewResult(ControllerContext controllerContext, int statusCode)
        {
            var errorController = _controllerFactory.CreateController(controllerContext.RequestContext, "Error");
            controllerContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            ((ErrorController)errorController).HandleHttpException(controllerContext.HttpContext, statusCode);
        }
    }

}
