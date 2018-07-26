using Mzl.Common.CacheHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mzl.Mojory.WebApi.Controllers.Session
{
    public class SessionController : Controller
    {
        // GET: Session
        public JsonResult Get(string key)
        {
            string value = RedisManager.GetData(key);
            return Json(new { value = value }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Set(string value) {
            string key = Guid.NewGuid().ToString();
            RedisManager.Set(value, key, TimeSpan.FromDays(1));
            return Json(new { key = key }, JsonRequestBehavior.AllowGet);
        }
    }
}