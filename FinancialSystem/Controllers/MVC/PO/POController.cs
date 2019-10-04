using FinancialSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public ActionResult PRList(SearchItemViewModel value) {
			
			return PartialView();
		}
	}
}