using FinancialSystem.Models.Enums;
using FinancialSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class NonCatalogViewModel {
		public long Id { get; set; }
		public string Name { get; set; }
		public long SubCategoryId { get; set; }
		public string Analysis { get; set; }
		public string RequestorId { get; set; }
		public string SecurityStamp { get; set; }
		public bool Approved { get; set; }



		public ICollection<NonCatalogLinesViewModel> Lines { get; set; }

	}
	public class NonCatalogLinesViewModel {
		public long Id { get; set; }
		public bool Selected { get; set; }
		public long SupplierId { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public virtual int Quantity { get; set; }
		public UOMType UOM { get; set; }
		public double Discount { get; set; }
		public double TotalAnount { get; set; }
		public AvailabilityType Availability { get; set; }
		public PaymentTermsType Terms { get; set; }
		public long BrandId { get; set; }
		public string TempSupplier { get; set; }
	}

}