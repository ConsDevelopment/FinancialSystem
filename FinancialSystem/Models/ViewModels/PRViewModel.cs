using FinancialSystem.Models.Enums;
using FinancialSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class PRViewModel {
		public long Id { get; set; }
		public string RequestorId { get; set; }
		public string DeliveryAdress { get; set; }
		public DateTime DateNeeded { get; set; }
		public string SecurityStamp { get; set; }
		public string NoteToBuyer { get; set; }
		public ICollection<PrLinesViewModel> Lines { get; set; }

	}
	public class PrLinesViewModel {
		public long Id { get; set; }
		public int Quantity { get; set; }
		public string SecurityStamp { get; set; }
		public string itemType { get; set; }
	}

	public class PRApprovalViewModel {
		public long Id { get; set; }
		public StatusType Status { get; set; }
		public string RequisitionNo { get; set; }
		public string SecurityStamp { get; set; }
	}


}