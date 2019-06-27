using FinancialSystem.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class PRViewModel {
		public string RequestorId { get; set; }
		public string DeliveryAdress { get; set; }
		public DateTime DateNeeded { get; set; }

	}
	
}