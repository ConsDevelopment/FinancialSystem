using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers.MVC.Maintenance
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult AddCompany()
        {
            return View();
        }
    }
}