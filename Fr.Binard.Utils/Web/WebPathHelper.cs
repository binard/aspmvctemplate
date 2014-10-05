using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fr.Binard.Net.Utils.Web
{
    public static class WebPathHelper
    {
        public static string GetPhysicalPath(string path)
        {
            return Path.IsPathRooted(path) ? path : HttpContext.Current.Server.MapPath(path);
        }
    }
}
