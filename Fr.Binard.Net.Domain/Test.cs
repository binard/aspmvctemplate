using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Binard.Net.Domain
{
    public class Test : IIdentifiable

    {
        public int ID { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }
    }
}
