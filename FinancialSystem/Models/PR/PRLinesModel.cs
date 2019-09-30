
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
	public class PRLinesModel {
		public virtual long Id { get; set; }
		public virtual ItemModel Item { get; set; }
		public virtual NonCatalogItemHeadModel NonCatalog { get; set; }
		public virtual SupplierModel Supplier { get; set; }
		public virtual int Quantity { get; set; }
		public virtual UOMType UOM { get; set; }
		public virtual string Description { get; set; }
		public virtual double UnitPrice { get; set; }
		public virtual double TotalAmount { get; set;  }
		
		public virtual UserModel CreatedBy { get; set; }
		public virtual PRHeaderModel Header { get; set; }

		public PRLinesModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class PRLinesModelMap : ClassMap<PRLinesModel> {
			public PRLinesModelMap() {
				Id(x => x.Id);
				Map(x => x.Quantity);
				Map(x => x.UOM);
				Map(x => x.Description);
				Map(x => x.UnitPrice);
				Map(x => x.TotalAmount);

				Map(x => x.DeleteTime);
				Map(x => x.CreateTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Item, "Item").Cascade.SaveUpdate();
				References(x => x.Item, "NonCatalog").Cascade.SaveUpdate();
				References(x => x.Supplier, "Supplier").Cascade.SaveUpdate();
				References(x => x.Header, "Header").Cascade.SaveUpdate();
			}
		}



		
	}

}
