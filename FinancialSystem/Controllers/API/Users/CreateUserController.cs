using FinancialSystem.Accessor.Users;
using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Users {
	public class CreateUserController : ApiController {
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
		public UserModel Post(UserModel source) {
			NHibernateUserStore store = new NHibernateUserStore();
			PasswordHasher ph = new PasswordHasher();
			
			var passHash = ph.HashPassword(source.Password);
			var usr = new UserModel() {
				UserName = source.UserName,
				FirstName = source.FirstName,
				LastName = source.LastName,
				PasswordHash= passHash,
				IsAdmin= source.IsAdmin
			};
			var createUser = new CreateUser();
			createUser.CreateUsers(usr);
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