using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.PR
{
    public class PRController : Controller
    {
        // GET: PR
        public ActionResult PRShop()
        {
			ViewData["ApiServer"] = Config.GetApiServerURL();
			return View();
        }
    }
}