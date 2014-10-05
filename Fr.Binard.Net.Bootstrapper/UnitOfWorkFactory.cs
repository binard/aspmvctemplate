using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Repository;
using Fr.Binard.Net.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Bootstrapper
{
    public class UnitOfWorkFactory : AbstractFactoryBase<IUnitOfWork>
    {
        public static Func<IUnitOfWork> GetDefault = () => NotIntializedFactory;
    }
}
