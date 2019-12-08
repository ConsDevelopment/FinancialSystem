using FinancialSystem.Models;
using FinancialSystem.Models.Company;
using FinancialSystem.NHibernate;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
		public async Task<string> Post(RegistrationView value) {
			var result = "Success";
			NHibernateCompanyStore store = new NHibernateCompanyStore();
			NHibernateUserStore user = new NHibernateUserStore();
			PasswordHasher ph = new PasswordHasher();
			var passHash = ph.HashPassword(value.password);
			var emp = new EmployeeModel() {
				FirstName = value.FirstName,
				LastName = value.LastName,
				Email = value.Email,
				EmpNo = value.EmpNo,
				Contact = value.Contact,
				Gender = value.Gender,
				Company = await store.GetCompanyByIdAsync(value.CompanyId),
				Team=await store.GetTeamByIdAsync(value.TeamId)	,
				position=await store.GetPositionByIdAsync(value.Job_Id),
				Department=await store.GetDepartmentByIdAsync(value.Dept_Id)

			};
			//var employee=await store.RegisterEmployeeAsync(emp);
			var usr = new UserModel() {
				UserName = value.Email,
				FirstName = value.FirstName,
				LastName = value.LastName,
				PasswordHash = passHash,
				employee = emp
			};
			await user.CreateAsync(usr);
			return result;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}