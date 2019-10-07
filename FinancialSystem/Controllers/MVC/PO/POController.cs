using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}