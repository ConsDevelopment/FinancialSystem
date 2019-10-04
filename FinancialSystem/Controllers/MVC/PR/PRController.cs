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
        public async Task<ActionResult> PRShop(string itemType="Catalog")
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

			ViewData["itemType"] = itemType;
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
		public async Task<ActionResult> NonCatalogSearch(SearchItemViewModel value) {
			var his = new NHibernateNonCatalogStore();
			value.searchItem = value.searchItem ?? "";
			ViewData["ItemImagePath"] = Config.GetAppSetting("ItemImagePath");
			int result;
			var isNumber = int.TryParse(value.searchItem, out result);
			IList<NonCatalogItemHeadModel> search = null;
			if (isNumber) {
				search = await his.FindIdNonCatalogHeadListAsync(result);
			} else {
				search = await his.SearchNonCatalogByNameAsync(value.searchItem);
			}
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
			var employees = new NHibernateCompanyStore();
			ViewData["pageName"] = "QuoteAnalysis";
			ViewData["Categories"] = await category.GeatAllCategoryAsync();
			ViewData["supplier"] = await supplier.GeatAllSupplierAsync();
			ViewData["brand"] = await supplier.GeatAllBrandAsync();
			ViewData["employees"] = await employees.GetAllEmployeeAsync();

			return View();
		}

		[Authorize(Roles = "Purchaser")]
		public async Task<ActionResult> UpdateViewQA(string search) {
			
			var nhnch = new NHibernateNonCatalogStore();
			var employees = new NHibernateCompanyStore();
			var category = new NHibernateCategoryStore();
			var supplier = new NHibernateISupplierStore();
			IList<NonCatalogItemHeadModel> nonCatalogHeads = null;
			
			ViewData["Categories"] = await category.GeatAllCategoryAsync();
			ViewData["pageName"] = "QuoteAnalysisUV";
			ViewData["employees"] = await employees.GetAllEmployeeAsync();
			ViewData["supplier"] = await supplier.GeatAllSupplierAsync();
			ViewData["brand"] = await supplier.GeatAllBrandAsync();

			long id;
			if (search == null) {
				nonCatalogHeads = await nhnch.FindLatestNonCatalogHeadAsync(10);
			} else if (long.TryParse(search, out id)) {
				nonCatalogHeads = await nhnch.FindIdNonCatalogHeadListAsync(id);
			} else {
				nonCatalogHeads = await nhnch.SearchNonCatalogByNameAsync(search);
			}
			return View(nonCatalogHeads);
		}
		
	}
}