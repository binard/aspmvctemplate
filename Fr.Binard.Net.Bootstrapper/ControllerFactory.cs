using System.Web;
using Fr.Binard.Net.Web.Core.Controllers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fr.Binard.Net.Bootstrapper
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public ControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                var controller = (Controller) _kernel.Get(controllerType);
                return controller;
            }
            else
            {
                var errorController = (ErrorController)GetControllerInstance(requestContext, typeof (ErrorController));
                errorController.HandleHttpException(requestContext.HttpContext, 404);
                return errorController;
            }
            

        }
    }
}
