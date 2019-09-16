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
	public class NHibernateCategoryStore {
		
		public async Task<SubCategoryModel> FindSubCategoryByIdAsync(long Id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<SubCategoryModel>(Id);
				}
			}
		}
		public async Task<IList<CategoryModel>> GeatAllCategoryAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var categories = db.QueryOver<CategoryModel>().Where(x => x.DeleteTime == null);
					return categories.List();
				}
			}
		}
		public async Task<IList<SubCategoryModel>> GeatSubCategoryAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<CategoryModel>(id).SubCategory.ToList();
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously