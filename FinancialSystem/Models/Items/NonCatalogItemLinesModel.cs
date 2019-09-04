
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
	public class NonCatalogItemLinesModel {
		public virtual long Id { get; set; }
		public virtual bool Selected { get; set; }
		public virtual SupplierModel Supplier { get; set; }
		public virtual double Price { get; set; }
		public virtual string Description { get; set; }
		public virtual int Quantity { get; set; }
		public virtual UOMType UOM { get; set; }
		public virtual double Discount { get; set; }
		public virtual double TotalAnount { get; set; }
		public virtual DateTime? Availability { get; set; }
		public virtual PaymentTermsType Terms { get; set; }
		public virtual BrandModel Brand { get; set; }


		public NonCatalogItemLinesModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}
		public virtual UserModel CreatedBy { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class NonCatalogItemLinesModelMap : ClassMap<NonCatalogItemLinesModel> {
			public NonCatalogItemLinesModelMap() {
				Id(x => x.Id);
				Map(x => x.Selected);
				Map(x => x.Price);
				Map(x => x.Description);
				Map(x => x.Quantity);
				Map(x => x.UOM).Length(40);
				Map(x => x.Discount);
				Map(x => x.TotalAnount);
				Map(x => x.Availability);
				Map(x => x.Terms);

				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Supplier, "Supplier").Cascade.SaveUpdate();
				References(x => x.Brand, "Brand").Cascade.SaveUpdate();
			}
		}



		
	}

}
