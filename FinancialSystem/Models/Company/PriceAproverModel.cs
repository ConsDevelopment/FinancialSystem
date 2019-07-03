
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialSystem.NHibernate;

namespace FinancialSystem.Models {
	public class PriceAproverModel {
		public virtual long Id { get; set; }
		public virtual PositionModel Approver { get; set; }
		public virtual double Min { get; set; }
		public virtual double Max { get; set; }
		public PriceAproverModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class PriceAproverModelMap : ClassMap<PriceAproverModel> {
			public PriceAproverModelMap() {
				Id(x => x.Id);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.Approver, "Approver").Cascade.SaveUpdate();
			}
		}



		
	}

}
