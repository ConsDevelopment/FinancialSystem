using FluentNHibernate.Mapping;
using FinancialSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.UserModels {

	public enum UserRoleType {
		Standard = 0,
		Purchaser = 1

	}

	public class UserRole : ILongIdentifiable {
		public virtual long Id { get; set; }
		public virtual UserRoleType RoleType { get; set; }
		public virtual UserRoleModel Role { get; set; }
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
				Map(x => x.RoleType).CustomType<UserRoleType>();
				References(x => x.Role, "Role").Cascade.SaveUpdate();
			}
		}
	}
}
