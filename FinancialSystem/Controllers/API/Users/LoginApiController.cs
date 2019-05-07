using FinancialSystem.Accessor.Users;
using FinancialSystem.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Users
{
    public class LoginApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [AllowAnonymous]
        [Access(AccessLevel.SignedOut)]
        public string Post(LoginViewModel value)
        {
			string Url = "";
			LoginAccessor la = new LoginAccessor();
			var user = la.LogIn(value);
			if (user != null) {
				Url = "../PR/PRShop";
			}
            return Url;

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}