using FinancialSystem.Models;
using FinancialSystem.Models.Enums;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.PO {
	public class SavingAdditionToPOController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task<long> Post(POViewModel value) {
			const long PurchaserHead = 6;
			var nhpos = new NHibernatePOStore();
			var nhus = new NHibernateUserStore();
			var company = new NHibernateCompanyStore();
			var po = await nhpos.FindPOAByIdAsync(value.Id);
			var user = await nhus.FindByStampAsync(value.SecurityStamp);
			foreach (var line in value.Lines) {
				var nhps = new NHibernatePRStore();
				var poLine = new POLinesModel() {
					Quantity = line.Quantity,
					UOM = line.UOM,
					Description = line.Description,
					UnitPrice = line.UnitPrice,
					PRLine = await nhps.GetPRLineAsync(line.PRLineId),
					Name = line.Name,
					CreatedBy = user
				};
				po.Lines.Add(poLine);
			}
			po.Status = value.Status;
			if (value.Status == StatusType.ForApproval) {
				
				var approver = new POAprovalModel() {
					Approver = await company.GetPositionByIdAsync(PurchaserHead),
					Status = StatusType.ForApproval

				};
				po.Approvals = new List<POAprovalModel>();
				po.Approvals.Add(approver);
				var costApprover = company.FindCostApprover(po.Amount);
				if (costApprover.Result != null) {
					var approver2 = new POAprovalModel() {
						Approver = costApprover.Result.Approver,
						Status = StatusType.ForApproval
					};
					po.Approvals.Add(approver2);
				}
			}
			await nhpos.SaveOrUpdatePOHeaderAsync(po);
			return value.Id;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}