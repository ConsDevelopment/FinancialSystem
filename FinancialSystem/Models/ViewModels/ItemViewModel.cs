using FinancialSystem.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class SearchItemViewModel {
		public string searchItem { get; set; }
	}

	//Maintenance Add Items
	public class AddingItemsViewModel {
		public string Name { get; set; }
		public string Code { get; set; }
		public string SKU  { get; set; }
		public string Description { get; set; }
		public string image { get; set; }
		public bool InStock { get; set; }
		public double Price { get; set; }
		public DateTime? PriceValidity { get; set; }
		public long SupplierId { get; set; }
		public long SubCategoryId { get; set; }
		public long BrandId { get; set; }

	}

	
}