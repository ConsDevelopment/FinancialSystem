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
	public class POApprovalController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task<IList<POApprovalViewModel>> Post(IList<POApprovalViewModel> value) {
			var nh = new NHibernateUserStore();
			var nhps = new NHibernatePOStore();
			List<POApprovalViewModel> POs= new List<POApprovalViewModel>();
			
				
					
					
					foreach (var approved in value) {
						var user = nh.FindByStampAsync(approved.SecurityStamp);
							if (user != null) {
							var approval=await nhps.FindPOAprovalAsync(approved.Id);
							approval.Status = approved.Status;
							switch(approval.Status)
							 {
								case StatusType.Approved: 
									var POApprovals = await nhps.FindPOAprovalAsync(approval.POHeader);
									approval.ApprovedBy = user.Result;
									approval.DateApproved = DateTime.UtcNow;
									foreach (var POApproval in POApprovals) {
										if (POApproval.Status == StatusType.Approved) {
											approval.POHeader.Status = StatusType.Approved;
										} else {
											approval.POHeader.Status = POApproval.Status;
											break;
										}
									}
									break;
								case StatusType.Rejected:
									approval.POHeader.Status = approval.Status;
									break;
								default:
									break;
							}
							try {
								await nhps.SaveOrUpdatePOApprovalAsync(approval);
							} catch (Exception e) {

							}
							approved.RequisitionNo = approval.POHeader.RequisitionNo;
							POs.Add(approved);
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