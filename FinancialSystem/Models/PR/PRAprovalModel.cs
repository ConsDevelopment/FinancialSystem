
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
	public class PRAprovalModel {
		public virtual long Id { get; set; }
		public virtual PositionModel Approver { get; set; }
		public virtual StatusType Status { get; set; }
		//public virtual PRHeaderModel PRHeader { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public virtual UserModel ApprovedBy { get; set; }
		public PRAprovalModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class PRAprovalModelMap : ClassMap<PRAprovalModel> {
			public PRAprovalModelMap() {
				Id(x => x.Id);
				Map(x => x.Status).CustomType<StatusType>();
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Approver, "Approver").Cascade.SaveUpdate();
				//References(x => x.PRHeader, "PRHeader").Cascade.SaveUpdate();
				References(x => x.ApprovedBy, "ApprovedBy").Cascade.SaveUpdate();

			}
		}



		
	}

}
