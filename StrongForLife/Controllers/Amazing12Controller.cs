using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongForLife.Controllers
{
    public class Amazing12Controller : Controller
    {
        //
        // GET: /Amazing12/

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Beta() {
			return View();
		}

		public ActionResult Confirm(string email) {
			ViewBag.Email = email;

			return View();
			
		}

    }
}
