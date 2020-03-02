using FinancialSystem.Models.Enums;
using FinancialSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialSystem.Models {
	
	public class ChargeLocationViewModel { 
		public string SecurityStamp { get; set; }
		public string ChargeLocationCode { get; set; }
		public string ChargeLocationName { get; set; }

	}
	public class CRCViewModel {
		public string SecurityStamp { get; set; }
		public string CRCCode { get; set; }
		public string CRCName { get; set; }

	}
	public class CompanyViewModel {
		public virtual long Id { get; set; }
		public virtual string CompanyName { get; set; }
		public virtual string CompanyCode { get; set; }
		public virtual string Phone { get; set; }
		public virtual string Address { get; set; }
		public virtual string Email { get; set; }
		public virtual string Logo { get; set; }
		public virtual string SmallLogo { get; set; }
		public virtual string Tin { get; set; }
		public string SecurityStamp { get; set; }
	}



	}