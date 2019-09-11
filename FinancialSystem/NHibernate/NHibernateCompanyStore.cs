using FinancialSystem.Models;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialSystem.NHibernate {
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
	public class NHibernateCompanyStore {
		public async Task RegisterEmployeeAsync(EmployeeModel employeeModel) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(employeeModel);
					tx.Commit();
					s.Flush();
				}
			}
		}
		public async Task<IList<EmployeeModel>> TeamEmployeeAsync(TeamModel team) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<EmployeeModel>().Where(x=>x.Team==team && x.DeleteTime==null).List();
				}
			}
		}
		public async Task<IList<EmployeeModel>> GetAllEmployeeAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<EmployeeModel>().Where(x =>  x.DeleteTime == null).List();
				}
			}
		}
		public async Task<EmployeeModel> GetEmployeeAsync(string id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<EmployeeModel>(id);
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously