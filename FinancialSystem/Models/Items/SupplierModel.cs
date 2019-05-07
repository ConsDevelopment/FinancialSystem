
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
	public class SupplierModel {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Contact { get; set; }
		public virtual string Address { get; set; }
		public virtual string TIN { get; set; }
		public virtual string ContactPerson { get; set; }
		public virtual string Email { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public SupplierModel() {
			
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class SupplierModelMap : ClassMap<SupplierModel> {
			public SupplierModelMap() {
				Id(x => x.Id);
				Map(x => x.Name);
				Map(x => x.Contact);
				Map(x => x.Address);
				Map(x => x.TIN);
				Map(x => x.ContactPerson);
				Map(x => x.Email);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();

			}
		}



		
	}

}
