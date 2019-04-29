using FinancialSystem.Models;
using FinancialSystem.Models.Company;
using FinancialSystem.NHibernate;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Company {
	public class RegisterController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public void Post(RegistrationView value) {
			NHibernateCompanyStore store = new NHibernateCompanyStore();
			PasswordHasher ph = new PasswordHasher();
			var passHash = ph.HashPassword(value.password);
			var emp = new EmployeeModel() {
				FirstName=value.FirstName,
				LastName=value.LastName,
				Email=value.Email,
				EmpNo=value.EmpNo,
				Contact=value.Contact,
				password= passHash

			};
			store.RegisterEmployee(emp);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}