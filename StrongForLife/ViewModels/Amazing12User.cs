using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongForLife.ViewModels {
	public class Amazing12UserViewModel {
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
		Yes = 1,
		No = 2,
		Sometimes = 3
	}

	public enum TrainingPreference {
		Morning = 1,
		Daytime = 2,
		Evenings = 3
	}
}