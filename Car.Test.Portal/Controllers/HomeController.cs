using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car.Test.Portal.Controllers
{
    public class HomeController : Controller
    {
        // first change
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
