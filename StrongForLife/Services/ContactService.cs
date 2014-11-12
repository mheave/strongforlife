using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

		public void SendAmazing12IntroductionEmail(string email) {
			var message = CreateSendGridMessage();
			message.AddTo(email);
			message.Subject = "The Amazing 12 week physique";
			message.Html = string.Format(GetEmailContentForEmailType(ContactType.Amazing12Initial), email);
			SendEmail(message);	

			var adminMessage = CreateSendGridMessage();
			adminMessage.AddTo("wearestrongforlife@gmail.com");
			adminMessage.Subject = "Amazing 12 interest";
			adminMessage.Html = string.Format(GetEmailContentForEmailType(ContactType.Amazing12InitialAdmin), email);
			SendEmail(adminMessage);	
		}

		public void SendAmazing12Admin(Amazing12UserViewModel applicant) {
			var adminMessage = CreateSendGridMessage();
			adminMessage.AddTo("mark.heaver@gmail.com");
			adminMessage.Subject = "Amazing 12 application completed";
			adminMessage.Html = string.Format(GetEmailContentForEmailType(ContactType.Amazing12Complete), applicant.FirstName, applicant.Surname,applicant.Email,applicant.MobileNumber,applicant.TakePartReason,applicant.Values,applicant.Motivation,applicant.DietSuccess,applicant.TrainingPreference);
			SendEmail(adminMessage);
		}


		private static string GetEmailContentForEmailType(ContactType emailType){
			string emailCopy;
			switch (emailType)
			{
				case ContactType.EnquiryAdmin:
					emailCopy = "<p>Enquiry recieved via website.</p><p>Name: {0}<br/>Email: {1}<br/>Tel: {2}</p>";
					break;
				case ContactType.NewsletterAdmin:
					emailCopy =  "<p>User {0} has requested to recieve a newsletter</p>";
					break;
				case ContactType.Amazing12Initial:
					emailCopy =		"<p>Thank for your interest in applying for the Amazing 12 Week Physique Body Transformation Program. You are really taking the first steps to positive changes.</p>";
					emailCopy +=	"<p>Almost there. Please follow the link below and this will take you to your application form. When you have answered the relevant sections, please submit your form.</p>";
					emailCopy +=	"<p><a href='http://www.wearestrongforlife.co.uk/Amazing12/Confirm?email={0}'>http://www.wearestrongforlife.co.uk/Amazing12/Confirm?email={0}</a></p>";
					emailCopy +=	"<p>We will then review your application and get back to you within 5 working days.</p>";
					emailCopy +=	"<p>Thank you for your time.</p>";
					emailCopy +=	"<p><em>\"a journey of a thousand miles begins with a single step\"</em></p>";
					break;
				case ContactType.Amazing12InitialAdmin:
					emailCopy =  "<p>Interest in Amazing 12 registered. Email address: <strong>{0}</strong></p>";
					break;
				case ContactType.Amazing12Complete:
					emailCopy =		"<p>Amazing 12 application completed with details:</p>";
					emailCopy +=	"<p>First name: {0}</p>";
					emailCopy +=	"<p>Surname: {1}</p>";
					emailCopy +=	"<p>Email: {2}</p>";
					emailCopy +=	"<p>Mobile number: {3}</p>";
					emailCopy +=	"<p>Take part reason: {4}</p>";
					emailCopy +=	"<p>Values: {5}</p>";
					emailCopy +=	"<p>Motivation: {6}</p>";
					emailCopy +=	"<p>Diet success: {7}</p>";
					emailCopy +=	"<p>Training time pref: {8}</p>";
					break;

				default:
					emailCopy = "";
					break;

			}

			return emailCopy;
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