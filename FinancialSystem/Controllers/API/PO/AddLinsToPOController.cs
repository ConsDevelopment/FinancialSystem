using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.PO {
	public class AddLinsToPOController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task<IList<POHeaderModel>> Post(IList<PrLinesViewModel> value) {
			List<POHeaderModel> POs = new List<POHeaderModel>();
			NHibernatePRStore nhprs = new NHibernatePRStore();
			NHibernatePOStore nhpos = new NHibernatePOStore();
			foreach (var line in value) {
				var prLine = await nhprs.GetPRLineAsync(line.Id);
				var searchPOs = await nhpos.FindPoWithSameSupplierAsync(prLine);
				if (searchPOs.Count > 0) {
					if (POs.Count > 0) {
						foreach(var po in searchPOs) {
							po.PoNumber = po.RequisitionNo;
							var AlreadyExists = POs.Contains(po);
							if (AlreadyExists == false) {
								POs.Add(po);
							}
						}
					} else {
						foreach (var po in searchPOs) {
							po.PoNumber = po.RequisitionNo;
							POs.Add(po);
						}
					}
				}
			}
			
			return POs;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}