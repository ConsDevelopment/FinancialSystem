using FinancialSystem.Controllers;
using FinancialSystem.Models;
using FinancialSystem.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialSystem.Accessor.Users {
	public class LoginAccessor : UserManagementController {
		public async Task<UserModel> LogIn(LoginViewModel model) {
			
			if (ModelState.IsValid) {
				var user = await UserManager.FindAsync(model.UserName.ToLower(), model.Password);
				if (user != null) {
					await SignInAsync(user, model.RememberMe);
					var usr = HibernateSession.GetCurrentSession();
				}
				return user;
			}
			return null;
		}
	}
}