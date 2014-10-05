using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fr.Binard.Net.Utils;

namespace Fr.Binard.Net.Web.Core.Settings
{
    public class AppSettings
    {
        public static string ApplicationName
        {
            get { return AppSettingsHelper.GetValue<string>("ApplicationName"); }
        }
    }
}
