
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
		public virtual UserModel CreatedBy { get; set; }
		public virtual PositionModel Approver { get; set; }
		public CategoryModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class CategoryModelMap : ClassMap<CategoryModel> {
			public CategoryModelMap() {
				Id(x => x.Id);
				Map(x => x.Name);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Approver, "Approver").Cascade.SaveUpdate();
			}
		}



		
	}

}
