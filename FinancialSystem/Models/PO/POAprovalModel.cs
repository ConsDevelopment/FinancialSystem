
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
	public class POAprovalModel {
		public virtual long Id { get; set; }
		public virtual PositionModel Approver { get; set; }
		public virtual StatusType Status { get; set; }
		public virtual POHeaderModel POHeader { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public virtual UserModel ApprovedBy { get; set; }
		public virtual DateTime? DateApproved { get; set; }
		public POAprovalModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class POAprovalModelMap : ClassMap<POAprovalModel> {
			public POAprovalModelMap() {
				Id(x => x.Id);
				Map(x => x.Status).Length(30).Update();
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				Map(x => x.DateApproved);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Approver, "Approver").Cascade.SaveUpdate();
				References(x => x.POHeader, "POHeader").Cascade.SaveUpdate();
				References(x => x.ApprovedBy, "ApprovedBy").Cascade.SaveUpdate();

			}
		}



		
	}

}
