using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fr.Binard.Net.Web.Core.Authentication
{
    public class UserSession
    {
        private const string SINGLETON_KEY = "__HttpRequestSingleton_UserSession";

        public static UserSession Instance
        {
            get
            {
                if (HttpContext.Current.Session[SINGLETON_KEY] == null)
                    HttpContext.Current.Session[SINGLETON_KEY] = new UserSession();

                return (UserSession) HttpContext.Current.Session[SINGLETON_KEY];
            }
        }

        private UserSession()        
        {
            // Initialisation des variables par défaut
        }
    }
}
