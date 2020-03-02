using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Company {
	public class AddingCompanyController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public async Task Post(CompanyViewModel value) {
			NHibernateCompanyStore nhcs = new NHibernateCompanyStore();
			var nhus = new NHibernateUserStore();
			var company = new CompanyModel() {
				CompanyCode=value.CompanyCode,
				CompanyName=value.CompanyName,
				Phone=value.Phone,
				Address=value.Address,
				Email=value.Email,
				Logo=value.Logo,
				SmallLogo=value.SmallLogo,
				Tin=value.Tin ,
				CreatedBy = await nhus.FindByStampAsync(value.SecurityStamp)
			};
			await nhcs.SaveOrUpdateCompany(company);
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}