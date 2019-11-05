
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
	public class POLinesModel {
		public virtual long Id { get; set; }
		public virtual int Quantity { get; set; }
		public virtual UOMType UOM { get; set; }
		public virtual string Description { get; set; }
		public virtual double UnitPrice { get; set; }
		public virtual POHeaderModel Header { get; set; }
		public virtual PRLinesModel PRLine { get; set; }
		public virtual string Name { get; set; }

		public POLinesModel() {
			CreateTime = DateTime.UtcNow;			
		}
		public virtual UserModel CreatedBy { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class POLinesModelMap : ClassMap<POLinesModel> {
			public POLinesModelMap() {
				Id(x => x.Id);
				Map(x => x.Quantity);
				Map(x => x.UOM).Length(20);
				Map(x => x.Description);
				Map(x => x.UnitPrice);
				Map(x => x.DeleteTime);
				Map(x => x.CreateTime);
				Map(x => x.Name).Length(30);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Header, "Header").Cascade.SaveUpdate();
				References(x => x.PRLine, "PRLine").Cascade.SaveUpdate();
			}
		}



		
	}

}
