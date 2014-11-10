using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using StrongForLife.Services;
using StrongForLife.ViewModels;
using SendGrid;


namespace StrongForLife.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

		ContactService _contactService = new ContactService();

        public ActionResult Index()
        {
			var enquiryViewModel = new EnquiryViewModel();
            return View(enquiryViewModel);
        }

		[HttpPost]
		public ActionResult Index(EnquiryViewModel enquiry) {
			_contactService.SendEnquiryNotification(enquiry);		
			return View("Success");
		}

		[HttpPost]
		public ActionResult NewsletterSignup(string email) {
			_contactService.SendNewsletterSubscriptionNotification(email);
			return View("NewsletterSuccess");
		}

		[HttpPost]
		public ActionResult Amazing12(string email) {
			_contactService.SendAmazing12IntroductionEmail(email);
			return View("Amazing12IntroductionSuccess");
		}
    }
}
