using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.Maintenance
{
    public class ChargeLocationController : Controller
    {
        // GET: ChargeLocation
        public ActionResult AddChargeLocation()
        {
            return View();
        }
    }
}