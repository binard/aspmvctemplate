using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fr.Binard.Net.Web.Core.Controllers
{
    public abstract class SiteControllerBase : Controller
    {
        protected int GetPageIndex(int? page)
        {
            return (page ?? 1);
        }
    }
}
