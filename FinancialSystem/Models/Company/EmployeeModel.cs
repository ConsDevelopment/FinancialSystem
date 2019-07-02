
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialSystem.Models {
	[DebuggerDisplay("{FirstName} {LastName}")]
	public class EmployeeModel  {
		public virtual string Id { get; set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Email { get; set; }
		public virtual string Contact { get; set; }
		public virtual string EmpNo { get; set; }
		public virtual string password { get; set; }
		public virtual GenderType? Gender { get; set; }
		public virtual string Image { get; set; }
		public virtual String Name() {
			return ((FirstName ?? "").Trim() + " " + (LastName ?? "").Trim()).Trim();
		}
		public EmployeeModel() {
			
			CreateTime = DateTime.UtcNow;
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }
		public virtual CompanyModel Company { get; set; }
		public virtual TeamModel Team { get; set; }
		public virtual PositionModel position { get; set; }
		public virtual PositionModel ImmediateLeader { get; set; }


		public class EmployeeModelMap : ClassMap<EmployeeModel> {
			public EmployeeModelMap() {
				Id(x => x.Id).CustomType(typeof(string)).GeneratedBy.Custom(typeof(GuidStringGenerator)).Length(36);
				Map(x => x.EmpNo).Index("EmpNo_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.FirstName);
				Map(x => x.LastName);
				Map(x => x.Email).Index("Email_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.Contact);
				Map(x => x.DeleteTime);
				Map(x => x.Gender).CustomType<GenderType>();
				Map(x => x.CreateTime);
				Map(x => x.password);
				Map(x => x.Image);
				References(x => x.Company, "Company").Cascade.SaveUpdate();
				References(x => x.Team, "Team").Cascade.SaveUpdate();
				References(x => x.position, "Position").Cascade.SaveUpdate();
				References(x => x.ImmediateLeader, "ImmediateLeader").Cascade.SaveUpdate();
			}
		}



		
	}

}
