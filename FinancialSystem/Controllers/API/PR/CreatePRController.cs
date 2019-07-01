using FinancialSystem.Accessor;
using FinancialSystem.Models;
using FinancialSystem.Models.Enums;
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
	public class CreatePRController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task Post(PRViewModel value) {
			var nh = new NHibernateUserStore();
			var nhps = new NHibernatePRStore();
			var session = HttpContext.Current.Session;
			var sessionKey = Config.GetAppSetting("SessionKey").ToString();
		
			if (session != null) {
				if (session[sessionKey] != null) {
					var user = await nh.FindByIdAsync(session[sessionKey].ToString());
					if (user != null) {

						var nhcs = new NHibernateCompanyStore();
						var utcDate = value.DateNeeded.ToUniversalTime();
						var requestor = await nhcs.GetEmployeeAsync(value.RequestorId);
						var prHeader = new PRHeaderModel() {
							Status = StatusType.Request,
							Requestor = requestor,
							DeliveryAdress = value.DeliveryAdress,
							DateNeeded = value.DateNeeded,
							CRC = requestor.Team.CRC,
							CreatedBy = user,
							Lines=new List<PRLinesModel>()
						};
						foreach (var line in value.Lines) {

							var lin = await nhps.GetPRLineAsync(line.Id);
							lin.Description = lin.Item.Description;
							lin.Supplier = lin.Item.Supplier;
							lin.UnitPrice = lin.Item.Price;
							lin.UOM = lin.Item.UOM;
							lin.TotalAmount = lin.Quantity * lin.UnitPrice;

							try {
								prHeader.Lines.Add(lin);
							} catch (Exception e) {

								}
							await nhps.CreatePRHeaderAsync(prHeader);
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