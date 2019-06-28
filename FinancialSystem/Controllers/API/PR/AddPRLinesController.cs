using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.PR {
	public class AddPRLinesController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task Post(PrLinesViewModel value) {
			var nh = new NHibernateUserStore();
			var nhps = new NHibernatePRStore();
			var session = HttpContext.Current.Session;
			var sessionKey = Config.GetAppSetting("SessionKey").ToString();
			if (session != null) {
				if (session[sessionKey] != null) {
					var user = await nh.FindByIdAsync(session[sessionKey].ToString());
					if (user != null) {
						var nhis = new NHibernateItemStore();
						var item = await nhis.FindItemByIdAsync(value.Id);
						var PrLines = new PRLinesModel {
							Item = item,
							Quantity = value.Quantity,
							CreatedBy = user
						};
						try {
							await nhps.CreatePRLinesAsync(PrLines);
						} catch (Exception e) {
							var a = e.Message;
						}
					}
				}
			}
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}