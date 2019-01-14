using FinancialSystem.Models;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialSystem.TestClass {
	public class TestCreateUser {
		public void CreateUser(UserModel userModel) {
			using (var s = HibernateSession.GetCurrentSession()) {
				using (var tx = s.BeginTransaction()) {
					s.Save(userModel);
					tx.Commit();
					s.Flush();
				}
			}
		}
		public void createUser() {
			var usr = new UserModel() {
				FirstName = "cons",
				LastName = "mname",
				UserName = "musername@del.com"
			};
			CreateUser(usr);
		}
	}
}