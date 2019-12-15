using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Maintenance {
	public class AddChargeLocationController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task Post(ChargeLocationViewModel value) { 
			var nhus = new NHibernateUserStore();
			var nhcs = new NHibernateCompanyStore();
			var chargeLocation = new ChargeLocationModel {
				ChargeLocationCode = value.ChargeLocationCode,
				ChargeLocationName=value.ChargeLocationName,
				CreatedBy=await nhus.FindByStampAsync(value.SecurityStamp)
			};
			await nhcs.AddChargeLocationAsync(chargeLocation);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}