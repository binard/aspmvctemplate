using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Utils
{
    public static class Clock
    {
        private static Func<DateTime> funct;

        static Clock()
        {
            funct = () => DateTime.Now;
        }

        public static DateTime Now
        {
            get
            {
                return funct();
            }
        }

        public static Func<DateTime> NowFunction
        {
            set
            {
                funct = value ?? (() => DateTime.Now);
            }
        }

        public static void Reset()
        {
            NowFunction = null;
        }
    }


}
