
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
	public class POHeaderModel {
		private string requisitionNo;
		public virtual long Id { get; set; }
		public virtual SupplierModel Supplier { get; set; }
		public virtual PaymentTermsType PaymentTerm { get; set; }
		public virtual EmployeeModel Requestor { get; set; }
		public virtual string DeliveryAdress { get; set; }
		public virtual StatusType Status { get; set; }
		public virtual DateTime? RequiredDate { get; set; }

		public virtual string RequisitionNo {
			get {
				string[] str = requisitionNo.Split('-');
				if (requisitionNo!=null && str.Length > 1) {
					requisitionNo = str[1];
				}
				return requisitionNo;
			}
			set {
				requisitionNo = value;
			}
		}
		public virtual CostRevenueCenterModel CRC { get; set; }		
		public virtual double Amount { get; set; }

		public virtual ICollection<PRLinesModel> Lines { get; set; }

		public POHeaderModel() {			
			CreateTime = DateTime.UtcNow;			
		}
		public virtual UserModel CreatedBy { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public class POHeaderModelMap : ClassMap<POHeaderModel> {
			public POHeaderModelMap() {
				Id(x => x.Id);
				Map(x => x.PaymentTerm).Length(20);
				Map(x => x.DeliveryAdress);
				Map(x => x.Status).Length(20);
				Map(x => x.RequiredDate);
				Map(x => x.RequisitionNo);
				Map(x => x.Amount);
				Map(x => x.CreateTime);
				Map(x => x.DeleteTime);
				References(x => x.Supplier, "Supplier").Cascade.SaveUpdate();
				References(x => x.Requestor, "Requestor").Cascade.SaveUpdate();
				References(x => x.CRC, "CRC").Cascade.SaveUpdate();
				HasMany(x => x.Lines).Cascade.SaveUpdate().KeyColumn("Header");
				References(x => x.CreatedBy, "CreatedBy").Cascade.SaveUpdate();
			}
		}

	}

}
