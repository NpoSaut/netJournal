using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Journal.Data;
using JournalApplication.ViewModels;

namespace JournalApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private const int UserId = 1;

        public ActionResult Index()
        {
            var model = new HomeViewModel("Евгений Плюснин",
                                          Enumerable.Range(0, 7)
                                                    .Select(i => DateTime.Today.AddDays(-i).AddHours(9))
                                                    .Select(d => new SessionViewModel(d, d.AddHours(9)))
                                                    .OrderBy(s => s.StartTime)
                                                    .ToList());
            return View(model);
        }
    }
}
