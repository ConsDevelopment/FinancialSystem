using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System.Threading.Tasks;

namespace FinancialSystem.Controllers.UserModels {
	public class LoginController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		[AcceptVerbs("GET", "POST")]
		public async Task<UserModel> Post(LoginModel login) {
			NHibernateUserStore store = new NHibernateUserStore();

			var usr = await store.FindByNamePassAsync(login.Username, login.Password);
			
			return usr;

			
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}