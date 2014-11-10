using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongForLife.Models {
	public class Amazing12User {
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public int MobileNumber { get; set; }
		public string TakePartReason { get; set; }
		public string Values { get; set; }
		public string Motivation { get; set; }
		public DietSuccess DietSuccess { get; set; }
		public TrainingPreference TrainingPreference { get; set; }

	}

	public enum DietSuccess
	{
		Yes,
		No,
		Sometimes
	}

	public enum TrainingPreference {
		Morning,
		Daytime,
		Evenings
	}
}