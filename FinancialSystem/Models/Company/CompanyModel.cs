
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
		public virtual string Address { get; set; }
		public virtual string Email { get; set; }
		public virtual string Logo { get; set; }
		public virtual string SmallLogo { get; set; }
		public virtual string Tin { get; set; }
		public virtual PositionModel Corfin { get; set; }

		public virtual UserModel CreatedBy { get; set; }
		public CompanyModel() {
		
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }


		public class CompanyModelMap : ClassMap<CompanyModel> {
			public CompanyModelMap() {
				Id(x => x.Id);
				Map(x => x.CompanyCode).Index("CompanyCode_IDX").Length(30).UniqueKey("uniq");
				Map(x => x.CompanyName);
				Map(x => x.Phone).Length(30);
				Map(x => x.Address);
				Map(x => x.Email).Length(60);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				Map(x => x.Logo);
				Map(x => x.SmallLogo);
				Map(x => x.Tin).Length(60);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Corfin, "Corfin").Cascade.SaveUpdate();
			}
		}



		
	}

}
