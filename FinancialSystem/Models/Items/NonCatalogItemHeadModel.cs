
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
	public class NonCatalogItemHeadModel {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual SubCategoryModel SubCategory { get; set; }
		public virtual string Analysis { get; set; }
		public virtual EmployeeModel Requestor { get; set; }
		
		public virtual ICollection<NonCatalogItemLinesModel> Lines { get; set; }

		public NonCatalogItemHeadModel() {
			Lines = new List<NonCatalogItemLinesModel>();
			CreateTime = DateTime.UtcNow;
			
		}
		public virtual UserModel CreatedBy { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class NonCatalogItemHeadModelMap : ClassMap<NonCatalogItemHeadModel> {
			public NonCatalogItemHeadModelMap() {
				Id(x => x.Id);
				Map(x => x.Name).Length(60);
				Map(x => x.Analysis);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.SubCategory, "SubCategory").Cascade.SaveUpdate();
				References(x => x.Requestor, "Requestor").Cascade.SaveUpdate();
				HasMany(x => x.Lines).Cascade.SaveUpdate().KeyColumn("Head");
			}
		}



		
	}

}
