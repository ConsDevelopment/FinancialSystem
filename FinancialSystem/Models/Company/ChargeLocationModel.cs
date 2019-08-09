
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
	public class ChargeLocationModel {
		public virtual long Id { get; set; }
		public virtual string ChargeLocationCode { get; set; }
		public virtual string ChargeLocationName { get; set; }

		public virtual UserModel CreatedBy { get; set; }
		public ChargeLocationModel() {
		
			CreateTime = DateTime.UtcNow;
			
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }


		public class ChargeLocationModelMap : ClassMap<ChargeLocationModel> {
			public ChargeLocationModelMap() {
				Id(x => x.Id);
				Map(x => x.ChargeLocationCode).Index("ChargeLocationCode_IDX").Length(20).UniqueKey("uniq");
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
			}
		}



		
	}

}
