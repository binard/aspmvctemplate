using System;
using Fr.Binard.Net.Utils;

namespace Fr.Binard.Net.Common.Log
{
    public class Logger : AbstractFactoryBase<ILogger>
    {
        public static Func<ILogger> Get = () => NotIntializedFactory;
    }
}
