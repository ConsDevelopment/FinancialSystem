
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
	public class PRHeader {
		public virtual long Id { get; set; }
		public virtual StatusType Status { get; set; }
		public virtual EmployeeModel Requestor { get; set; }
		public virtual string DeliveryAdress { get; set; }
		public virtual ChargeLocationModel CLC { get; set; }
		public virtual string RequisitionNo { get;set;  }
		public virtual DateTime DateNeeded { get; set;  }
		public virtual CostRevenueCenterModel CRC { get; set; }
		public virtual UserModel CreatedBy { get; set; }
		public virtual string CategoryAccountCode { get; set; }
		public virtual ICollection<PRLines> Lines { get; set; }

		public PRHeader() {
			
			CreateTime = DateTime.UtcNow;
			RequisitionNo = CRC.BusinesUnit.BUCode + DateTime.UtcNow.Month.ToString().PadLeft(2, '0') + Id.ToString().PadLeft(5,'0');
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class PRHeaderMap : ClassMap<PRHeader> {
			public PRHeaderMap() {
				Id(x => x.Id);
				Map(x => x.Status).CustomType<StatusType>();
				Map(x => x.DeliveryAdress);
				Map(x => x.RequisitionNo);
				Map(x => x.DateNeeded);
				Map(x => x.CategoryAccountCode);
				Map(x => x.DeleteTime);
				Map(x => x.CreateTime);
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
				References(x => x.CLC, "CLC").Cascade.SaveUpdate();
				References(x => x.CRC, "CRC").Cascade.SaveUpdate();
				References(x => x.Requestor, "Requestor").Cascade.SaveUpdate();
				HasMany(x => x.Lines).Cascade.SaveUpdate().KeyColumn("Header");
			}
		}

	}

}
