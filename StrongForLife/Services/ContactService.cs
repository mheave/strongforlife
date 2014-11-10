using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using SendGrid;
using StrongForLife.ViewModels;

namespace StrongForLife.Services {
	public class ContactService 
	{

		public void SendEnquiryNotification(EnquiryViewModel enquiry) {
		
			var message = CreateSendGridMessage();
			// Send to admin
			message.AddTo("wearestrongforlife@gmail.com");
			message.Subject = "Enquiry from website";
			message.Html = string.Format(GetEmailContentForEmailType(ContactType.EnquiryAdmin), enquiry.Name, enquiry.Email, enquiry.TelNo);
			SendEmail(message);						
		}

		public void SendNewsletterSubscriptionNotification(string email) {
			var message = CreateSendGridMessage();
			message.AddTo("wearestrongforlife@gmail.com");
			message.Subject = "Newsletter signup";
			message.Html = string.Format(GetEmailContentForEmailType(ContactType.NewsletterAdmin), email);
			SendEmail(message);	
		}


		private string GetEmailContentForEmailType(ContactType emailType) {

			switch (emailType)
			{
				case ContactType.EnquiryAdmin:
					return "<p>Enquiry recieved via website.</p><p>Name: {0}<br/>Email: {1}<br/>Tel: {2}</p>";
				case ContactType.NewsletterAdmin:
					return "<p>User {0} has requested to recieve a newsletter</p>";
				default:
					return "";
			}

		}

		private SendGridMessage CreateSendGridMessage() {
			var emailMessage = new SendGridMessage();
			emailMessage.From = new MailAddress("coach@wearestrongforlife.co.uk");
			return emailMessage;
		}

		private void SendEmail(SendGridMessage message) {
			var credentials = new NetworkCredential("azure_30e3ac2fdfd17d5e9daa1e0f6365ac99@azure.com", "I2ivj2daL9U1v5y");
			var transportWeb = new Web(credentials);
			transportWeb.Deliver(message);	
		}
	}

	enum ContactType
	{
		Enquiry,
		EnquiryAdmin,
		Newsletter,
		NewsletterAdmin,
		Amazing12Initial,
		Amazing12InitialAdmin,
		Amazing12Complete
	}
}