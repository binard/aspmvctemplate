using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Utils
{
    public abstract class AbstractFactoryBase<T>
    {
            protected static T NotIntializedFactory
            {
                get
                {
                    throw new ApplicationException(String.Format("Factory for {0} is not intialized", typeof(T).Name));
                }
            }
    }
}
