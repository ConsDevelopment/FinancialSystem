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

namespace FinancialSystem.Controllers.MVC.PO
{
	
	public class POController : Controller
    {
		
		public ActionResult PRSearch()
        {
			return View();
        }
		[Authorize(Roles = "Purchaser")]
		public async Task<ActionResult> PRList(SearchItemViewModel value) {
		
			value.searchItem = value.searchItem ?? "";
			var nhpa = new NHibernatePRStore();
			IList<PRHeaderModel> searchPRs=null;
			try {
				searchPRs = await nhpa.SearchPRAsync(value.searchItem);
			} catch (Exception e) {
			}
			return PartialView(searchPRs);
		}
		[Authorize(Roles = "Purchaser")]
		public async Task<ActionResult> POCreation(IList<PrLinesViewModel> value) {
			var nhpa = new NHibernatePRStore();
			PRHeaderModel PR = null;
			var prLines = new List<PRLinesModel>();
			foreach (var line in value) {
				var prLine = await nhpa.GetPRLineAsync(line.Id);
				prLines.Add(prLine);
				if (PR == null) {
					PR = prLine.Header;
				}
			}
			ViewData["PR"] = PR;
			return PartialView(prLines);
		}
		[Authorize(Roles = "Purchaser")]
		public ActionResult POSearch() {
			return View();
		}
		[Authorize(Roles = "Purchaser")]
		public async Task<ActionResult> POList(SearchItemViewModel value) {

			value.searchItem = value.searchItem ?? "";
			var nhpa = new NHibernatePOStore();
			IList<POHeaderModel> searchPOs = null;
			try {
				searchPOs = await nhpa.SearchPRAsync(value.searchItem);
			} catch (Exception e) {
			}
			return PartialView(searchPOs);
		}

		public async Task<ActionResult> POApprover() {
			var nh = new NHibernateUserStore();
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
			var nhps = new NHibernatePOStore();
			var pr = await nhps.FindPOApprovalAsync(user.employee.position);
			return View(pr);
		}

	}
}