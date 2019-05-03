
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;
using FinancialSystem.NHibernate;
using System.Threading.Tasks;

namespace FinancialSystem.Models {
	public class CompanyModel  {
		public virtual long Id { get; set; }
		public virtual string CompanyName { get; set; }
		public virtual string CompanyCode { get; set; }
		public virtual string Phone { get; set; }
		public virtual string Adress { get; set; }
		public virtual string Email { get; set; }
		
		public virtual UserModel CreatedBy { get; set; }
		public CompanyModel() {
		
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }


		public class CompanyModelMap : ClassMap<CompanyModel> {
			public CompanyModelMap() {
				Id(x => x.Id);
				Map(x => x.CompanyCode).Index("CompanyCode_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.CompanyName);
				Map(x => x.Phone);
				Map(x => x.Adress);
				Map(x => x.Email);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(p => p.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
			}
		}



		
	}

}
