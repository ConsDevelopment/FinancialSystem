
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
	public class CategoryModel {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual Task<UserModel> CreatedBy { get; set; }
		public CategoryModel() {
			NHibernateUserStore nu = new NHibernateUserStore();
			CreateTime = DateTime.UtcNow;
			CreatedBy = nu.FindByIdAsync(CurrentUserSession.userSession);
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class CategoryModelMap : ClassMap<CategoryModel> {
			public CategoryModelMap() {
				Id(x => x.Id);
				Map(x => x.Name);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy).Column("CreatedBy").ReadOnly();
				
			}
		}



		
	}

}
