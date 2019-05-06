using FinancialSystem.Models.UserModels;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
			if (CurrentUserSession.userSession != null) {
				var user = await nh.FindByIdAsync(CurrentUserSession.userSession);
				return View(user);
			} else if (CurrentUserSession.userSecurityStampCookie != null) {
				var user = await nh.FindByStampAsync(CurrentUserSession.userSecurityStampCookie);
				CurrentUserSession.userSession = user.Id;
				return View(user);
			} else {
				return View("../Users/Login");
			}
			
			
        }
    }
}