using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrongForLife.ViewModels {
	public class EnquiryViewModel {
		[Required(ErrorMessage = "Please enter your name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter a valid email address")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter a valid phone number")]
		public int TelNo { get; set; }
	}
}