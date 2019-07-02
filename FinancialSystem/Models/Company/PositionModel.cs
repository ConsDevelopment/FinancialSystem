
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
	//This serves as Section 
	public class PositionModel {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public virtual ICollection<EmployeeModel> employees { get; set; }
		public PositionModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }
		

		public class PositionModelMap : ClassMap<PositionModel> {
			public PositionModelMap() {
				Id(x => x.Id);
				Map(x => x.Name);
				Map(x => x.Description);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				HasMany(x => x.employees).Cascade.SaveUpdate().KeyColumn("Position");

			}
		}



		
	}

}
