using FinancialSystem.Controllers;
using FinancialSystem.Models;
using FinancialSystem.Models.UserModels;
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
				try {
					var user = await UserManager.FindAsync(model.UserName.ToLower(), model.Password);
					if (user != null && user.DeleteTime == null) {
						HibernateSession.SignInUser(user, model.RememberMe);


						return user;
					} else {
						CurrentUserSession.removeSecurityStampCookie();
						return null;
					}
				}catch		 (Exception e) {
					return null;
				}
				
			}
			return null;
		}
	}
}