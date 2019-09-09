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
	public class NHibernateISupplierStore {
		
		public async Task<SupplierModel> FindSupplierByIdAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<SupplierModel>(Id);
				}
			}
		}
		public async Task<IList<SupplierModel>> GeatAllSupplierAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var supplier = db.QueryOver<SupplierModel>().Where(x => x.DeleteTime == null);
					return supplier.List();
				}
			}
		}
		public async Task<BrandModel> FindBrandByIdAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<BrandModel>(Id);
				}
			}
		}

	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously