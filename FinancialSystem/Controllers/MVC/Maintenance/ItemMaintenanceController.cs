using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.Maintenance
{
    public class ItemMaintenanceController : Controller
    {
        // GET: ItemMaintenance
        public async Task<ActionResult> AddItems() {
			var branditems = new NHibernateItemStore();
			var suppliernames = new NHibernateISupplierStore();

			ViewData["BrandItems"] = await branditems.GetAllBrandNameAsync();

			ViewData["SupplierNames"] = await suppliernames.GeatAllSupplierAsync();

			return View();
        }

    }
}