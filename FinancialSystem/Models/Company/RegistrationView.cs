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
		public string Dept_Id { get; set; }
		public string Job_Id { get; set; }
		public string password { get; set; }
	}
}