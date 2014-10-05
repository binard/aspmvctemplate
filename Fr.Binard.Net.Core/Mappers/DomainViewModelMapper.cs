using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Web.Core.ViewModels;

namespace Fr.Binard.Net.Web.Core.Mappers
{
    public class DomainViewModelMapper : IMapper
    {
        public void Map()
        {
            MapTest();
        }

        private static void MapTest()
        {
            Mapper.CreateMap<Test, TestViewModel>();
            Mapper.CreateMap<TestViewModel, Test>();
        }
    }
}
