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
			//var sessionKey = Config.GetAppSetting("SessionKey").ToString();



			var user = nh.FindByStampAsync(value.SecurityStamp);
			if (user != null) {
				var nhcs = new NHibernateCompanyStore();
				var utcDate = value.DateNeeded.ToUniversalTime();
				var requestor = await nhcs.GetEmployeeAsync(value.RequestorId);
				DateTime dateNeeded;
				if (value.DateNeeded < DateTime.UtcNow) {
					dateNeeded = DateTime.UtcNow.AddDays(6);
				} else {
					dateNeeded = value.DateNeeded;
				}
						var prHeader = new PRHeaderModel() {
							Status = StatusType.Request,
							Requestor = requestor,
							DeliveryAdress = value.DeliveryAdress,
							DateNeeded = dateNeeded,
							CRC = requestor.Team.CRC,
							CreatedBy = user.Result,
							Lines=new List<PRLinesModel>(),
							Approvals=new List<PRAprovalModel>(),

						};
						if (requestor.ImmediateLeader != null) {
							var immedieateAprover = new PRAprovalModel() {
								Approver= requestor.ImmediateLeader,
								Status=StatusType.Request,
								CreatedBy=user.Result
							};

							prHeader.Approvals.Add(immedieateAprover);
						}
						if (requestor.Department != null) {

							
							if (!prHeader.Approvals.Any(s => s.Approver.Id == requestor.Department.DepartmentLeader.Id)){
								var DepLeadAproval = new PRAprovalModel() {
									Approver = requestor.Department.DepartmentLeader,
									Status = StatusType.Request,
									CreatedBy = user.Result
								};
								prHeader.Approvals.Add(DepLeadAproval);
							}
						}
						if (requestor.Company.Corfin != null && requestor.Company.Corfin.Id!=requestor.position.Id) {
						
							
							if (!prHeader.Approvals.Any(s => s.Approver.Id == requestor.Company.Corfin.Id)) {
								var corfin = new PRAprovalModel() {
									Approver = requestor.Company.Corfin,
									Status = StatusType.Request,
									CreatedBy = user.Result
								};
								prHeader.Approvals.Add(corfin);
							}
						}
						foreach (var line in value.Lines) {
							
							var lin = await nhps.GetPRLineAsync(line.Id);
					if (lin.Item != null) {
						if (lin.Item.SubCategory != null) {

							if (!prHeader.Approvals.Any(s => s.Approver.Id == lin.Item.SubCategory.Category.Approver.Id)) {
								var ItemAproval = new PRAprovalModel() {
									Approver = lin.Item.SubCategory.Category.Approver,
									Status = StatusType.Request,
									CreatedBy = user.Result
								};
								prHeader.Approvals.Add(ItemAproval);
							}
						}
						lin.Description = lin.Item.Description;
						lin.Supplier = lin.Item.Supplier;
						lin.UnitPrice = lin.Item.Price;
						lin.UOM = lin.Item.UOM;
					} else {
						if (lin.NonCatalog.SubCategory != null) {
							if (!prHeader.Approvals.Any(s => s.Approver.Id == lin.NonCatalog.SubCategory.Category.Approver.Id)) {
								var ItemAproval = new PRAprovalModel() {
									Approver = lin.NonCatalog.SubCategory.Category.Approver,
									Status = StatusType.Request,
									CreatedBy = user.Result
								};
								prHeader.Approvals.Add(ItemAproval);
							}
						}
						var item =lin.NonCatalog.Lines.Where(x => x.Selected == true && x.DeleteTime == null).SingleOrDefault();
						lin.Description = item.Description;
						lin.Supplier = item.Supplier;
						lin.UnitPrice = item.Price;
						lin.UOM = item.UOM;
					}
							
							lin.TotalAmount = lin.Quantity * lin.UnitPrice;
							prHeader.Amount += lin.TotalAmount;
							prHeader.Lines.Add(lin);
							
							
						}
				try {
					await nhps.CreatePRHeaderAsync(prHeader);
				} catch (Exception e) {
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