using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Fr.Binard.Net.Common.Map
{
    public static class MapperHelper
    {
        public static T MapTo<T>(this object originObject)
            where T : class
        {
            return Mapper.Map<T>(originObject);
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> originEnumerable)
            where T : class
        {
            return originEnumerable.Select(e => e.MapTo<T>());
        }
    }
}
