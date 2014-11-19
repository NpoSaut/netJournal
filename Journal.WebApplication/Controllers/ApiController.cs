using System;
using System.Web.Mvc;

namespace Journal.WebApplication.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public JsonResult CurrentTime() { return Json(DateTime.Now, JsonRequestBehavior.AllowGet); }
    }
}
