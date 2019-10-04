using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.PO
{
	
	public class POController : Controller
    {
		[Authorize(Roles = "Purchaser")]
		public ActionResult PRSearch()
        {
            return View();
        }
    }
}