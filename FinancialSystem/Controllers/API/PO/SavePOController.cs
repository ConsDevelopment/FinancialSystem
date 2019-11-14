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
	public class SavePOController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task<string> Post(POViewModel value) {
			const long PurchaserHead = 6;
			var nhss = new NHibernateISupplierStore();
			var nhcs = new NHibernateCompanyStore();
			var nhpos = new NHibernatePOStore();
			var nhus = new NHibernateUserStore();
			var company = new NHibernateCompanyStore();
			var requierDate = value.RequiredDate < DateTime.UtcNow ? DateTime.UtcNow.AddDays(6) : value.RequiredDate;
			var user = await nhus.FindByStampAsync(value.SecurityStamp);
			var requestor = await nhcs.GetEmployeeAsync(value.RequestorId);
			var po = await nhpos.FindPOAByIdAsync(value.Id);
			if (po == null) {
				po = new POHeaderModel() {
					Supplier = await nhss.FindSupplierByIdAsync(value.SupplierId),
					PaymentTerm = value.PaymentTerm,
					Requestor = requestor,
					DeliveryAdress = value.DeliveryAdress,
					Status = value.Status,
					RequiredDate = requierDate,
					NoteToBuyer = value.NoteToBuyer,
					CreatedBy = user,
					Amount = value.Amount,
					CRC = requestor.Team.CRC,
					Lines = new List<POLinesModel>()
				};
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
			} else {
				po.Requestor = await nhcs.GetEmployeeAsync(value.RequestorId);
				po.DeliveryAdress = value.DeliveryAdress;
				po.Amount = value.Amount;
				for(var i=0;i<po.Lines.Count;i++) {
					var found = false;
					var id = po.Lines.ElementAt(i).Id;
					foreach(var line in value.Lines) {
						if (line.Id == id) {
							found = true;
							po.Lines.ElementAt(i).Quantity = line.Quantity;
							po.Lines.ElementAt(i).UOM = line.UOM;
							po.Lines.ElementAt(i).Description = line.Description;
							po.Lines.ElementAt(i).UnitPrice = line.UnitPrice;
							break;
						} 
					}
					if (found == false) {
						po.Lines.ElementAt(i).DeleteTime = DateTime.UtcNow;
					}
					
				}
				

			}
			if (value.Status == StatusType.ForApproval) {
				var approver = new POAprovalModel() {
					Approver= await company.GetPositionByIdAsync(PurchaserHead),
					Status=StatusType.ForApproval
					
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

			try {
				await nhpos.SaveOrUpdatePOHeaderAsync(po);
			} catch (Exception e) {
			}
			return po.RequisitionNo;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}