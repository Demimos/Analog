using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Analog.Controllers
{
    /// <summary>
    /// Сводное описание для TimeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
     [System.Web.Script.Services.ScriptService]
    public class TimeService : System.Web.Services.WebService
    {

        [WebMethod]
        public int[] GetTime(string zone)
        {
            var offset = TimeZoneInfo.GetSystemTimeZones().First(z => z.Id == zone).BaseUtcOffset;
            var d = DateTime.UtcNow.AddHours(offset.Hours).AddMinutes(offset.Minutes);
            return new int[] { d.Hour, d.Minute, d.Second };
        }
    }
}
