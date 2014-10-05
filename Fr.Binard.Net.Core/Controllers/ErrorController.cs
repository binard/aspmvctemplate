using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fr.Binard.Net.Web.Core.ViewModels;

namespace Fr.Binard.Net.Web.Core.Controllers
{
    public class ErrorController : ErrorControllerBase
    {
        public ErrorController(IControllerFactory controllerFactory)
            : base(controllerFactory)
        {

        }

        public ActionResult Http404(string url)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            var model = GetModel(url);
            return View("404", model);
        }

        public ActionResult Http500(string url)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var model = GetModel(url);
            return View("500", model);
        }

        public ActionResult Generic(string url, int statusCode)
        {
            Response.StatusCode = statusCode;
            var model = GetModel(url);
            return View("Error", model);
        }

        private NotFoundViewModel GetModel(string url)
        {
            var model = new NotFoundViewModel();

            model.RequestedUrl = Request.Url != null && Request.Url.OriginalString.Contains(url) & Request.Url.OriginalString != url ? Request.Url.OriginalString : url;
            model.ReferrerUrl = Request.UrlReferrer != null && Request.UrlReferrer.OriginalString != model.RequestedUrl ? Request.UrlReferrer.OriginalString : null;

            return model;
        }

    }
}
