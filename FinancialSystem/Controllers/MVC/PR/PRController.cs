using FinancialSystem.Accessor.Users;
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

			//var task =  (Task)HttpContext.Session[Config.GetAppSetting("SessionKey")];
			var user = (UserModel)HttpContext.Session[Config.GetAppSetting("SessionKey")];
			//UserModel user=null;
			if (user != null) {
				//user =(UserModel) task.GetType().GetProperty("Result").GetValue(task);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				HttpContext.Session[Config.GetAppSetting("SessionKey")] = user;
				
				var owinAuthentication = new OwinAuthenticationService(HttpContext);
				owinAuthentication.SignIn(user);
			} else {
				return RedirectToAction("Login", "User");
			}
			var nhps = new NHibernatePRStore();
			var lines = await nhps.PRLinesCreatedAsync(user);
			ViewData["cartCount"] = lines.Count;
			ViewData["CompanyLogo"] = Config.GetCompanyLogo(user.employee.Company.Logo);
			ViewData["UserProfilePict"] = Config.GetUserProfilePict(user.employee.Image);
			ViewData["ItemImagePath"] = Config.GetAppSetting("ItemImagePath");
			
			return View(user);
		}

		public async Task<ActionResult> ItemSearch(SearchItemViewModel value) {
			var his = new NHibernateItemStore();
			value.searchItem = value.searchItem ?? "";
			var search = await his.SearchItemAsync(value.searchItem);
			ViewData["ItemImagePath"] = Config.GetAppSetting("ItemImagePath");
			return PartialView(search);

		}
		public async Task<ActionResult> ReviewCart() {
			var nh = new NHibernateUserStore();
			ViewData["ApiServer"] = Config.GetApiServerURL();

			var response = new HttpResponseMessage(HttpStatusCode.OK);

			var user = (UserModel)HttpContext.Session[Config.GetAppSetting("SessionKey")];
			//UserModel user = null;
			if (user != null) {
				//user = (UserModel)task.GetType().GetProperty("Result").GetValue(task);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				HttpContext.Session[Config.GetAppSetting("SessionKey")] = user;
				var owinAuthentication = new OwinAuthenticationService(HttpContext);
				owinAuthentication.SignIn(user);
			} else {
				return RedirectToAction("Login", "User");
			}
			var nhps = new NHibernatePRStore();
			var lines = await nhps.PRLinesCreatedAsync(user);
			ViewData["cartCount"] = lines.Count;
			ViewData["UserProfilePict"] = Config.GetUserProfilePict(user.employee.Image);
			ViewData["CompanyLogo"] = Config.GetCompanyLogo(user.employee.Company.Logo);
			ViewData["ItemImagePath"] = Config.GetAppSetting("ItemImagePath");
			
			return View(lines);

		}

		public async Task<ActionResult> CreatePR(IList<PrLinesViewModel> value) {
			List<PRLinesModel> lines=new List<PRLinesModel>();
			var nhps = new NHibernatePRStore();
			var nh = new NHibernateUserStore();
			var nhcs = new NHibernateCompanyStore();
			var user = (UserModel)HttpContext.Session[Config.GetAppSetting("SessionKey")];
			//UserModel user = null;
			if (user != null) {
				//user = (UserModel)task.GetType().GetProperty("Result").GetValue(task);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				HttpContext.Session[Config.GetAppSetting("SessionKey")] = user;
				var owinAuthentication = new OwinAuthenticationService(HttpContext);
				owinAuthentication.SignIn(user);
			} else {
				return RedirectToAction("Login", "User");
			}
			ViewData["SmallLogo"] = Config.GetCompanyLogo(user.employee.Company.SmallLogo);
			ViewData["Employee"] = user.employee;
			ViewData["Section"] = await nhcs.TeamEmployeeAsync(user.employee.Team);
			foreach (var item in value) {
				var line = await nhps.GetPRLineAsync(item.Id);
				lines.Add(line);
				
			}
			return PartialView(lines);
		}
		public async Task<ActionResult> PRAproover() {
			var nh = new NHibernateUserStore();
			ViewData["ApiServer"] = Config.GetApiServerURL();

			var response = new HttpResponseMessage(HttpStatusCode.OK);

			var user = (UserModel)HttpContext.Session[Config.GetAppSetting("SessionKey")];
			//UserModel user = null;
			if (user != null) {
				//user = (UserModel)task.GetType().GetProperty("Result").GetValue(task);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				HttpContext.Session[Config.GetAppSetting("SessionKey")] = user;
				var owinAuthentication = new OwinAuthenticationService(HttpContext);
				owinAuthentication.SignIn(user);
			} else {
				return RedirectToAction("Login", "User");
			}
			var nhps = new NHibernatePRStore();
			var pr = await nhps.FindPRAprovalAsync(user.employee.position);
			return View(pr);
		}
		[Authorize(Roles = "Purchaser")]
		public async Task<ActionResult> QuoteAnalysis() {
			var category = new NHibernateCategoryStore();
			var supplier = new NHibernateISupplierStore();
			ViewData["pageName"] = "QuoteAnalysis";
			ViewData["Categories"] = await category.GeatAllCategoryAsync();
			ViewData["supplier"] = await supplier.GeatAllSupplierAsync();
			ViewData["brand"] = await supplier.GeatAllBrandAsync();


			return View();
		}
	}
}