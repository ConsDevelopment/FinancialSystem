
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
	public class CostAproverModel {
		public virtual long Id { get; set; }
		public virtual PositionModel Approver { get; set; }
		public virtual double Min { get; set; }
		public virtual double Max { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public CostAproverModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class CostAproverModelMap : ClassMap<CostAproverModel> {
			public CostAproverModelMap() {
				Id(x => x.Id);
				Map(x => x.Min);
				Map(x => x.Max);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Approver, "Approver").Cascade.SaveUpdate();
				
			}
		}



		
	}

}
