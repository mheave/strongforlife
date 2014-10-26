using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StrongForLife.ViewModels;


namespace StrongForLife.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
			var enquiryViewModel = new EnquiryViewModel();
            return View(enquiryViewModel);
        }

		[HttpPost]
		public ActionResult Index(EnquiryViewModel enquiry) {
			
			return View("Success");
		}

    }
}
