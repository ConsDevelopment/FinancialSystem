using FinancialSystem.Models.Enums;
using FinancialSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class POViewModel {
		public long Id { get; set; }
		public long SupplierId { get; set; }
		public PaymentTermsType PaymentTerm { get; set; }
		public string RequestorId { get; set; }
		public string DeliveryAdress { get; set; }
		public StatusType Status { get; set; }
		public DateTime RequiredDate { get; set; }
		public string SecurityStamp { get; set; }
		public string NoteToBuyer { get; set; }
		public virtual double Amount { get; set; }
		public ICollection<POLinesViewModel> Lines { get; set; }

	}
	public class POLinesViewModel {
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public UOMType UOM { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public long PRLineId { get; set; }
		
	}


}