using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StrongForLife.Services;
using StrongForLife.ViewModels;

namespace StrongForLife.Controllers
{
    public class Amazing12Controller : Controller
    {
        ContactService _contactService = new ContactService();

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

		public ActionResult CompleteSubmission(Amazing12UserViewModel amazing12User) {
			_contactService.SendAmazing12Admin(amazing12User);


			return View();
		}

    }
}
