using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Utils
{
    public static class AppSettingsHelper
    {
        public static T GetValue<T>(string key)
        {
            string settingValue = ConfigurationManager.AppSettings[key];
            if (settingValue == null)
                throw new KeyNotFoundException(String.Format("The key '{0}' is missing in appSettings section of config", key));

            return Converter.ChangeType<T>(settingValue);
        }

    }
}
