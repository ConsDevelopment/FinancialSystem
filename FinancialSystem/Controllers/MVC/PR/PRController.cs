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

			var session = HttpContext.Session["UserId"];
			if (!string.IsNullOrEmpty(session as string)) {
				var user = await nh.FindByIdAsync(session.ToString());
				ViewData["CompanyLogo"] = Config.GetCompanyLogo(user.employee.Company.Logo);
				ViewData["UserProfilePict"] = Config.GetUserProfilePict(user.employee.Image);
				return View(user);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				var user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				ViewData["CompanyLogo"] = Config.GetCompanyLogo(user.employee.Company.Logo);
				ViewData["UserProfilePict"] = Config.GetUserProfilePict(user.employee.Image);
				HttpContext.Session["UserId"] = user.Id;
				return View(user);
			} else {
				return RedirectToAction("Login", "User");
			}
        }
    }
}