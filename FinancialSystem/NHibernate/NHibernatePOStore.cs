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
		


	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously