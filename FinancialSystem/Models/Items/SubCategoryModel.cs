
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
	public class SubCategoryModel {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public virtual CategoryModel Category { get; set; }
		public SubCategoryModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class SubCategoryModelMap : ClassMap<SubCategoryModel> {
			public SubCategoryModelMap() {
				Id(x => x.Id);
				Map(x => x.Name);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.Category, "Category").Cascade.SaveUpdate();
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();

			}
		}



		
	}

}
