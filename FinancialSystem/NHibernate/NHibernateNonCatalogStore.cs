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
		public async Task<NonCatalogItemHeadModel> GetNonCatalogAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<NonCatalogItemHeadModel>(id);
				}
			}
		}

		public async Task<IList<NonCatalogItemHeadModel>> FindLatestNonCatalogHeadAsync(int count) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<NonCatalogItemHeadModel>().Where(x => x.DeleteTime == null).OrderBy(x=>x.CreateTime).Desc.Take(count).List();

				}
			}
		}
		public async Task<IList<NonCatalogItemHeadModel>> FindIdNonCatalogHeadAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<NonCatalogItemHeadModel>().Where(x => x.DeleteTime == null && x.Id==id).OrderBy(x => x.CreateTime).Desc.List();

				}
			}
		}
		public async Task<IList<NonCatalogItemHeadModel>> SearchNonCatalogByNameAsync(string search) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var items = db.QueryOver<NonCatalogItemHeadModel>().Where(Restrictions.On<NonCatalogItemHeadModel>(x => x.Name).IsLike(search + "%") && Restrictions.On<NonCatalogItemHeadModel>(x => x.DeleteTime).IsNull);
					return items.List();
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously