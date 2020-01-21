using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string Zones)
        {
            var selected = (Zones == null) ? TimeZoneInfo.Local.Id : HttpUtility.HtmlDecode(Zones);
            ViewData["current"] = selected;
            ViewBag.Zones = TimeZoneInfo.GetSystemTimeZones().Select(z=>new SelectListItem() { 
                Value=z.Id,
                Text=z.DisplayName,
                Selected=z.Id.Equals(selected)
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