using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fr.Binard.Net.Utils.Web
{
    public class HttpRequestSingleton<T>
    {
        private static string _singletonKey = "__HttpRequestSingleton_" + typeof(T).FullName;

        private static readonly object _syncRoot = new object();

        private T _value;
        private bool _isSet;

        public T Value 
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _isSet = true;
            }
        }

        public bool IsSet
        {
            get
            {
                return _isSet;
            }
        }

        public static HttpRequestSingleton<T> Instance
        {
            get
            {
                lock (_syncRoot)
                {
                    if (HttpContext.Current.Items[_singletonKey] == null)
                    {
                        HttpContext.Current.Items[_singletonKey] = new HttpRequestSingleton<T>();
                    }
                }
                return (HttpRequestSingleton<T>)HttpContext.Current.Items[_singletonKey];
            }
        }

        private HttpRequestSingleton()
        {
        }
    }
}
