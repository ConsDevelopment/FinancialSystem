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
	public class NHibernateItemStore {
		public async Task<IList<ItemModel>> SearchItemAsync(string search) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var items= db.QueryOver<ItemModel>().Where(Restrictions.On<ItemModel>(x=>x.Name).IsLike(search+"%") || Restrictions.On<ItemModel>(x => x.SKU).IsLike(search.ToLower() + "%"));
					return items.List();
				} 
			}
		}
		public async Task<ItemModel> FindItemByIdAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<ItemModel>(Id);
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously