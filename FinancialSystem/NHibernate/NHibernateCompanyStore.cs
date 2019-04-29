using FinancialSystem.Models;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.NHibernate {
	public class NHibernateCompanyStore {
		public void RegisterEmployee(EmployeeModel employeeModel) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(employeeModel);
					tx.Commit();
					s.Flush();
				}
			}
		}
	}
}