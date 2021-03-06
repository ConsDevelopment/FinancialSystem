﻿using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Maintenance {
	public class AddCRCController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task Post(CRCViewModel value) {
			var nhus = new NHibernateUserStore();
			var nhcs = new NHibernateCompanyStore();
			var CRC = new CostRevenueCenterModel {
				CRCCode = value.CRCCode,
				CRCName = value.CRCName,
				CreatedBy = await nhus.FindByStampAsync(value.SecurityStamp)
			};
			await nhcs.AddCRCAsync(CRC);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}