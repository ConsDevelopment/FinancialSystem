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
		public async Task<EmployeeModel> RegisterEmployeeAsync(EmployeeModel employeeModel) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(employeeModel);
					tx.Commit();
					s.Flush();
					return employeeModel;
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
		public async Task<IList<CompanyModel>> GetAllCompanyAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<CompanyModel>().Where(x => x.DeleteTime == null).List();
				}
			}
		}
		public async Task<CompanyModel> GetCompanyByIdAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<CompanyModel>(id);
				}
			}
		}
		public async Task SaveOrUpdateCompany(CompanyModel company) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(company);
					tx.Commit();
					s.Flush();
				}
			}
		}
		public async Task<IList<DepartmentModel>> GetAllDepartmentAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<DepartmentModel>().Where(x => x.DeleteTime == null).List();
				}
			}
		}
		public async Task<DepartmentModel> GetDepartmentByIdAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<DepartmentModel>(id);
				}
			}
		}
		public async Task<IList<TeamModel>> GetAllTeamAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<TeamModel>().Where(x => x.DeleteTime == null).List();
				}
			}
		}
		public async Task<TeamModel> GetTeamByIdAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<TeamModel>(id);
				}
			}
		}
		public async Task<IList<PositionModel>> GetAllPositionAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<PositionModel>().Where(x => x.DeleteTime == null).List();
				}
			}
		}
		public async Task<PositionModel> GetPositionByIdAsync(long id) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.Get<PositionModel>(id);
				}
			}
		}

		public async Task<CostAproverModel> FindCostApprover(double amount) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<CostAproverModel>().Where(x =>  amount>=x.Min && amount <= x.Max ).SingleOrDefault();
				}
			}
		}
		public async Task AddChargeLocationAsync(ChargeLocationModel CLC) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(CLC);
					tx.Commit();
					s.Flush(); 
				}
			}
		}
		public async Task AddCRCAsync(CostRevenueCenterModel CRC) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(CRC);
					tx.Commit();
					s.Flush();
				}
			}
		}
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously