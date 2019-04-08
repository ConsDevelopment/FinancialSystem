using FluentNHibernate.Mapping;
using FinancialSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.UserModels {

	public enum UserRoleType {
		Standard = 0,
		PlaceholderOnly = 1,
		LeadershipTeamMember = 2,
		AccountContact = 100,
		EmailBlackList = 9999,

	}

	public class UserRole : ILongIdentifiable {
		public virtual long Id { get; set; }
		public virtual long UserId { get; set; }
		public virtual long OrgId { get; set; }
		public virtual UserRoleType RoleType { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public UserRole() {
			CreateTime = DateTime.UtcNow;
		}

		public class Map : ClassMap<UserRole> {
			public Map() {
				Id(x => x.Id);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				Map(x => x.UserId);
				Map(x => x.OrgId);
				Map(x => x.RoleType).CustomType<UserRoleType>();
			}
		}
	}
}
