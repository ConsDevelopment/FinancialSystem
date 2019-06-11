
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
	public class BusinessUnitModel {
		public virtual long Id { get; set; }
		public virtual string BUCode { get; set; }
		public virtual string BUName { get; set; }
		public virtual CompanyModel Company { get; set; }
		

		public virtual UserModel CreatedBy { get; set; }
		public BusinessUnitModel() {
		
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }


		public class BusinessUnitModelMap : ClassMap<BusinessUnitModel> {
			public BusinessUnitModelMap() {
				Id(x => x.Id);
				Map(x => x.BUCode).Index("CRCCode_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.BUName);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.Company, "Company").Cascade.SaveUpdate();

			}
		}



		
	}

}
