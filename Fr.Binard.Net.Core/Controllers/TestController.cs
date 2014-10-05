using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Fr.Binard.Net.Common;
using Fr.Binard.Net.Common.Log;
using Fr.Binard.Net.Common.Map;
using Fr.Binard.Net.Domain;
using Fr.Binard.Net.Service;
using Fr.Binard.Net.Web.Core.Authentication;
using Fr.Binard.Net.Web.Core.ViewModels;
using PagedList;

namespace Fr.Binard.Net.Web.Core.Controllers
{
    public class TestController : SiteControllerBase
    {
        private readonly ITestService _service;

        public TestController(ITestService service)
        {
            _service = service;
        }

        // GET: Test
        public ActionResult Index(int? page)
        {
            Logger.Get().Info("Liste of Tests");
            var list = _service.GetAll().MapTo<TestViewModel>().ToPagedList(GetPageIndex(page), 10);
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestViewModel test)
        {
            if (!ModelState.IsValid)
                return View(test);

            _service.Add(test.MapTo<Test>());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var test = _service.GetById(id);
            if(test == null)
                throw new HttpException(404, "Not Found");

            return View(test.MapTo<TestViewModel>());
        }

        [HttpPost]
        public ActionResult Edit(TestViewModel test)
        {
            if (!ModelState.IsValid)
                return View(test);

            _service.Update(test.MapTo<Test>());
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Crash()
        {
            throw new NotImplementedException();
        }



    }
}