using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.Accessor.Users {
	public class CreateUser {
		public void CreateUsers(UserModel userModel) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(userModel);
					tx.Commit();
					s.Flush();
				}
			}
		}

		
	}
}