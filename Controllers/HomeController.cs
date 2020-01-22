using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Zones = TimeZoneInfo.GetSystemTimeZones().Select(z=>new SelectListItem() { 
                Value=z.Id,
                Text=z.DisplayName,
                Selected=z.Id.Equals(TimeZoneInfo.Local.Id)
            });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}