using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mzl.Mojory.WebApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: Home
        public string Index()
        {
            return "Hello";
        }
    }
}