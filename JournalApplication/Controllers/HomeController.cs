using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JournalApplication.Models.Burndown;
using JournalApplication.ViewModels;

namespace JournalApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

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

        public JsonResult Burndown(DateTime From, DateTime To)
        {
            var r = new Random();
            const int pointsCount = 10;
            const double hoursCount = 40;
            TimeSpan dur = To - From;
            List<PointModel> points = Enumerable
                .Range(0, pointsCount)
                .Select(i => new PointModel(From.AddTicks((long)((double)dur.Ticks * i / pointsCount)),
                                            (1.0 + 0.3 * r.NextDouble()) * hoursCount * i / pointsCount)).ToList();
            return Json(new
                        {
                            StartTime = From,
                            EndTime = To,
                            PointsData = points
                        }, JsonRequestBehavior.AllowGet);
        }
    }
}
