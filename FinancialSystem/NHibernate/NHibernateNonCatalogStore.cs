using FinancialSystem.Models;
using FinancialSystem.Utilities;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialSystem.NHibernate {


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public class NHibernateNonCatalogStore {
		public async Task<long> CreateNonCatalogHeadAsync(NonCatalogItemHeadModel Head) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					db.Save(Head);
					tx.Commit();
					db.Flush();
					return Head.Id;
				}
			}

		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously