using System.Web;
using System.Web.Mvc;

namespace Fr.Binard.Net.Bootstrapper
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
