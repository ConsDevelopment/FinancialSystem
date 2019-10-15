using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.Maintenance
{
    public class ItemMaintenanceController : Controller
    {
        // GET: ItemMaintenance
        public ActionResult Additems()
        {
            return View();
        }

        public ActionResult RemoveItems()
        {
            return View();
        }
    }
}