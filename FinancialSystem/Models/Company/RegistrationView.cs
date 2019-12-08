using FinancialSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Models.Company {
	public class RegistrationView {

		public  string FirstName { get; set; }
		public  string LastName { get; set; }
		public  string Email { get; set; }
		public  string Contact { get; set; }
		public  string EmpNo { get; set; }
		public long Dept_Id { get; set; }
		public long Job_Id { get; set; }
		public string password { get; set; }
		public GenderType Gender { get; set; }
		public long CompanyId { get; set; }
		public long TeamId { get; set; }
	}
}