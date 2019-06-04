using FinancialSystem.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class SearchItemViewModel {
		public string searchItem { get; set; }
	}
	public class AddPrLinesViewModel {
		public long Id { get; set; }
		public int Quantity { get; set; }
	}
}