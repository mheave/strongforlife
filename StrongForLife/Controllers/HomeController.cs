using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongForLife.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AboutUs() {
			return View();
		}

		public ActionResult Services() {
			return View();
		}

		public ActionResult Timetable() {
			return View();
		}

		public ActionResult Gallery() {
			return View();
		}

    }
}
