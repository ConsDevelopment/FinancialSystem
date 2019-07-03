using FinancialSystem.Accessor;
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
	public class NHibernatePRStore {
		//public async Task<IList<ItemModel>> CreatePRLinesAsync(string search) {
		//	using (var db = HibernateSession.GetCurrentSession()) {
		//		using (var tx = db.BeginTransaction()) {
		//			var items= db.QueryOver<ItemModel>().Where(Restrictions.On<ItemModel>(x=>x.Name).IsLike(search+"%") || Restrictions.On<ItemModel>(x => x.SKU).IsLike(search.ToLower() + "%"));
		//			return items.List();
		//		} 
		//	}
		//}

		public async Task CreatePRLinesAsync(PRLinesModel line) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					db.Save(line);
					tx.Commit();
					db.Flush();
				}
			}
		}

		public async Task<IList<PRLinesModel>> PRLinesCreatedAsync(UserModel user) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var lines = db.QueryOver<PRLinesModel>().Where(x=>x.CreatedBy==user && x.DeleteTime==null);
					return lines.List();
				}
			}
		}

		public async Task DeletePRLineAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var line = db.Get<PRLinesModel>(Id);
					line.DeleteTime = DateTime.UtcNow;
					db.SaveOrUpdate(line);
					tx.Commit();
					db.Flush();
				}
			}
		}
		public async Task<PRLinesModel> GetPRLineAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<PRLinesModel>(Id);
				}
			}
		}
		public async Task CreatePRHeaderAsync(PRHeaderModel header) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					db.Save(header);
					var pra = new PRAccessor();
					header.RequisitionNo = pra.GetRequisitionNo(header.Requestor, header.Id);
					db.Update(header);
					try {
						tx.Commit();
					} catch (Exception e) {

					}
					db.Flush();
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously