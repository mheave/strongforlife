using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using StrongForLife.ViewModels;
using SendGrid;


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
			var htmlEmailContent = "Name: {0}, Email: {1}, Tel: {2}"	;
			var emailMessage = new SendGridMessage();
			emailMessage.From = new MailAddress("coach@wearestrongforlife.co.uk");
			emailMessage.AddTo("wearestrongforlife@gmail.com");
			emailMessage.Subject = "Enquiry from website";
			emailMessage.Text = string.Format(htmlEmailContent, enquiry.Name, enquiry.Email, enquiry.TelNo);
			
			// Create credentials, specifying your user name and password.
			var credentials = new NetworkCredential("azure_30e3ac2fdfd17d5e9daa1e0f6365ac99@azure.com", "I2ivj2daL9U1v5y");

			// Create an Web transport for sending email.
			var transportWeb = new Web(credentials);

			// Send the email.
			// You can also use the **DeliverAsync** method, which returns an awaitable task.
			transportWeb.Deliver(emailMessage);			


			return View("Success");
		}
    }
}
