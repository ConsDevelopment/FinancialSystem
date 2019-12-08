using FinancialSystem.Models.UserModels;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Register()
        {
			NHibernateCompanyStore nhcs = new NHibernateCompanyStore();
			var Companies = await nhcs.GetAllCompanyAsync();
			var Positions = await nhcs.GetAllPositionAsync();
			var Departments = await nhcs.GetAllDepartmentAsync();
			var Teams = await nhcs.GetAllTeamAsync();
			var Employees = await nhcs.GetAllEmployeeAsync();
			ViewData["Companies"] = Companies;
			ViewData["Positions"] = Positions;
			ViewData["Departments"] = Departments;
			ViewData["Teams"] = Teams;
			ViewData["Employees"] = Employees;
			ViewData["ApiServer"] = Config.GetApiServerURL();
            return View();
        }
        public ActionResult Login()
        {
            ViewData["ApiServer"] = Config.GetApiServerURL();
			
			return View();
        }
    }
}