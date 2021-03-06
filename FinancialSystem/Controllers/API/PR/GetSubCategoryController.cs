﻿using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.PR {
	public class GetSubCategoryController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		
		public async Task<IList<SubCategoryModel>> Get(long id) {
			var category = new NHibernateCategoryStore();
			var sub= await category.GeatSubCategoryAsync(id);
			return sub;
		}

		// POST api/<controller>
		public void Post([FromBody]string value) {
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}