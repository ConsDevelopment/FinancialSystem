using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.Users
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

		// GET: User
		public ActionResult CreateUser() {
			ViewData["ApiServer"] = Config.GetApiServerURL();
			return View();
		}
	}
}