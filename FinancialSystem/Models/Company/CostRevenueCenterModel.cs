
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;
using FinancialSystem.NHibernate;
using System.Threading.Tasks;

namespace FinancialSystem.Models {
	public class CostRevenueCenterModel {
		public virtual long Id { get; set; }
		public virtual string CRCCode { get; set; }
		public virtual string CRCName { get; set; }
		
		

		public virtual UserModel CreatedBy { get; set; }
		public CostRevenueCenterModel() {
		
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }


		public class CostRevenueCenterModelMap : ClassMap<CostRevenueCenterModel> {
			public CostRevenueCenterModelMap() {
				Id(x => x.Id);
				Map(x => x.CRCCode).Index("CRCCode_IDX").Length(30).UniqueKey("uniq");
				Map(x => x.CRCName);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				

			}
		}



		
	}

}
