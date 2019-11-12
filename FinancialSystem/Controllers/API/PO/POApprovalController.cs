﻿using FinancialSystem.Models;
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
		public async Task<IList<PRApprovalViewModel>> Post(IList<PRApprovalViewModel> value) {
			var nh = new NHibernateUserStore();
			var nhps = new NHibernatePOStore();
			List<PRApprovalViewModel> PRs= new List<PRApprovalViewModel>();
			
				
					
					
					foreach (var approved in value) {
						var user = nh.FindByStampAsync(approved.SecurityStamp);
							if (user != null) {
							var approval=await nhps.FindPRAprovalAsync(approved.Id);
							approval.Status = approved.Status;
							switch(approval.Status)
							 {
								case StatusType.Approved: 
									var PRApprovals = await nhps.FindPRAprovalAsync(approval.PRHeader);
									approval.ApprovedBy = user.Result;
									approval.DateApproved = DateTime.UtcNow;
									foreach (var PRApproval in PRApprovals) {
										if (PRApproval.Status == StatusType.Approved) {
											approval.PRHeader.Status = StatusType.Approved;
										} else {
											approval.PRHeader.Status = PRApproval.Status;
											break;
										}
									}
									break;
								case StatusType.Rejected:
									approval.PRHeader.Status = approval.Status;
									break;
								default:
									break;
							}
							try {
								await nhps.SaveOrUpdatePRApprovalAsync(approval);
							} catch (Exception e) {

							}
							approved.RequisitionNo = approval.PRHeader.RequisitionNo;
							PRs.Add(approved);
						}
					}
				
			
			return PRs;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}