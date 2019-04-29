
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;

namespace FinancialSystem.Models {
	public class TeamModel {
		public virtual long Id { get; set; }
		public virtual string TeamName { get; set; }
		public virtual string TeamCode { get; set; }
		public virtual string CreatedBy { get; set; }

		public TeamModel() {
			
			CreateTime = DateTime.UtcNow;
			CreatedBy = CurrentUserSession.userSession;
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public virtual ICollection<EmployeeModel> Employee { get; set; }
		public virtual string TeamLeader { get; set; }

		public class TeamModelMap : ClassMap<TeamModel> {
			public TeamModelMap() {
				Id(x => x.Id);
				Map(x => x.TeamCode).Index("TeamCode_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.TeamName);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				Map(x => x.CreatedBy);
				HasMany(x => x.Employee).Cascade.SaveUpdate();
				Map(x => x.TeamLeader);
			}
		}



		
	}

}
