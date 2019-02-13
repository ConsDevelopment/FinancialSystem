using FinancialSystem.Models;
using FinancialSystem.NHibernate;
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
		public async void createUser() {
			NHibernateUserStore store = new NHibernateUserStore();
			var usr = new UserModel() {
				FirstName = "cons",
				LastName = "mname",
				UserName = "myusername5@del.com"
			
			};
			CreateUser(usr);
			await store.SetPasswordAsync(usr, "test2");
		}

		public async void PasswordTesting() {

			NHibernateUserStore store = new NHibernateUserStore();
			var usr = await store.FindByIdAsync("ef9826e1-86b8-41c4-8716-a9e60123db20");
			await store.SetPasswordAsync(usr, "test2");
		}
	}
}