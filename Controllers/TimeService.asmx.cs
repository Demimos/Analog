using Newtonsoft.Json;
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
        public string GetTime(string zone)
        {
            DateTime d;
            if (zone ==null)
                d = DateTime.Now;
            else
            {
                var tzone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(z => z.Id == zone);
                if (tzone==null)
                    d = DateTime.Now;
                else
                    d = DateTime.UtcNow.AddHours(tzone.BaseUtcOffset.Hours).AddMinutes(tzone.BaseUtcOffset.Minutes);
            }
            return JsonConvert.SerializeObject(new int[] { d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, d.Millisecond});
        }
    }
}
