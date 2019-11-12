using FinancialSystem.Accessor;
using FinancialSystem.Models;
using FinancialSystem.Models.Enums;
using FinancialSystem.Utilities;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialSystem.NHibernate {


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public class NHibernatePOStore {
		

		public async Task SaveOrUpdatePOHeaderAsync(POHeaderModel header) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {				
					db.SaveOrUpdate(header);
					var poa = new PRAccessor();
					if (header.RequisitionNo == null) {
						header.RequisitionNo = poa.GetRequisitionNo(header.Requestor, header.Id);
						db.Update(header);
					}
					tx.Commit();
					db.Flush();
				}
			}
		}
		public async Task<IList<POHeaderModel>> SearchPRAsync(string search) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					POHeaderModel po = null;
					EmployeeModel emp = null;
					DepartmentModel dep = null;
					var items = db.QueryOver<POHeaderModel>(() => po)
						.JoinAlias(() => po.Requestor, () => emp)
						.JoinAlias(() => emp.Department, () => dep)
						.Where(x => po.DeleteTime == null  && (po.RequisitionNo.IsLike("%" + search + "%")
						|| emp.LastName.IsLike(search + "%")
						|| dep.Name.IsLike(search + "%"))).OrderBy(() => po.CreateTime).Desc.Take(10);

					return items.List();
				}
			}
		}
		public async Task<IList<POAprovalModel>> FindPOApprovalAsync(PositionModel approver) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<POAprovalModel>().Where(x => x.Approver == approver && x.Status == StatusType.ForApproval)
						.JoinQueryOver(x => x.POHeader).Where(a => a.Status == StatusType.ForApproval).List();

				}
			}
		}



	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously