using FinancialSystem.Models;
using FinancialSystem.Models.UserModels;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace FinancialSystem.Controllers.MVC.PR
{
    public class PRController : Controller
    {
        // GET: PR
        public async Task<ActionResult> PRShop()
        {
			NHibernateUserStore nh = new NHibernateUserStore();
			ViewData["ApiServer"] = Config.GetApiServerURL();
			
			HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

			var session = HttpContext.Session[Config.GetAppSetting("SessionKey")];
			UserModel user;
			if (!string.IsNullOrEmpty(session as string)) {
				user = await nh.FindByIdAsync(session.ToString());				
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
			} else {
				return RedirectToAction("Login", "User");
			}
			ViewData["CompanyLogo"] = Config.GetCompanyLogo(user.employee.Company.Logo);
			ViewData["UserProfilePict"] = Config.GetUserProfilePict(user.employee.Image);
			ViewData["ItemImagePath"] = Config.GetAppSetting("ItemImagePath");
			HttpContext.Session[Config.GetAppSetting("SessionKey")] = user.Id;
			return View(user);
		}
    }
}