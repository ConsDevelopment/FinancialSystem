
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
	public class TeamModel {
		public virtual long Id { get; set; }
		public virtual string TeamName { get; set; }
		public virtual string TeamCode { get; set; }
		public virtual Task<UserModel> CreatedBy { get; set; }

		public TeamModel() {
			NHibernateUserStore nu = new NHibernateUserStore();
			CreateTime = DateTime.UtcNow;
			CreatedBy = nu.FindByIdAsync(CurrentUserSession.userSession);
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public virtual ICollection<EmployeeModel> Employee { get; set; }
		public virtual EmployeeModel TeamLeader { get; set; }

		public class TeamModelMap : ClassMap<TeamModel> {
			public TeamModelMap() {
				Id(x => x.Id);
				Map(x => x.TeamCode).Index("TeamCode_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.TeamName);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy).Column("CreatedBy").ReadOnly();
				HasMany(x => x.Employee).ReadOnly();
				References(x => x.TeamLeader);
			}
		}



		
	}

}
