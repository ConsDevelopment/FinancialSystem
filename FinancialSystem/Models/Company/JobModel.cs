
using System.Diagnostics;
using FluentNHibernate.Mapping;
using FinancialSystem.Models.Enums;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using FinancialSystem.Models.UserModels;
using System.Collections.Generic;

namespace FinancialSystem.Models {
	public class JobModel  {
		public virtual long Id { get; set; }
		public virtual string JobTitle { get; set; }
		public virtual string JobeCode { get; set; }
		public virtual string CreatedBy { get; set; }
		public JobModel() {
			
			CreateTime = DateTime.UtcNow;
			CreatedBy = CurrentUserSession.userSession;
		}

		public virtual DateTime CreateTime { get; set; }
		public virtual DateTime? DeleteTime { get; set; }

		public virtual ICollection<EmployeeModel> Employee { get; set; }

		public class JobModelMap : ClassMap<JobModel> {
			public JobModelMap() {
				Id(x => x.Id);
				Map(x => x.JobeCode).Index("JobCode_IDX").Length(400).UniqueKey("uniq");
				Map(x => x.JobTitle);
				Map(x => x.CreatedBy);
				HasMany(x => x.Employee).Cascade.SaveUpdate();
			}
		}



		
	}

}
