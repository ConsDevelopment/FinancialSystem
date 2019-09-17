using FinancialSystem.Models;
using FinancialSystem.NHibernate;
using FinancialSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.PR {
	public class AddNonCatalogController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		[Authorize(Roles = "Purchaser")]
		public async Task<long> Post(NonCatalogViewModel value) {
			const long PurchaserHead = 6;


			var user = new NHibernateUserStore();
			var nnc = new NHibernateNonCatalogStore();
			var supplierStore = new NHibernateISupplierStore();
			var subcategoryStore = new NHibernateCategoryStore();
			var company = new NHibernateCompanyStore();
			var createdby = await user.FindByStampAsync(value.SecurityStamp);
			var nonCatalog = new NonCatalogItemHeadModel {
				Name = value.Name,
				Analysis = value.Analysis,
				SubCategory = await subcategoryStore.FindSubCategoryByIdAsync(value.SubCategoryId),
				Requestor = await company.GetEmployeeAsync(value.RequestorId),
				CreatedBy = createdby,
				Approver = await company.GetPositionByIdAsync(PurchaserHead)
			};
			
			foreach (var line in value.Lines) {
				var supplier = await supplierStore.FindSupplierByIdAsync(line.SupplierId);
				string tempSuppliee = null;
				if (supplier == null) {
					tempSuppliee = line.TempSupplier;
				}
				var nonCatalogLine = new NonCatalogItemLinesModel {
					Selected = line.Selected,
					Supplier = supplier,
					Price=line.Price,
					Description=line.Description,
					Quantity=line.Quantity,
					UOM=line.UOM,
					Discount=line.Discount,
					TotalAnount=line.TotalAnount,
					Availability=line.Availability,
					Terms=line.Terms,
					Brand= await supplierStore.FindBrandByIdAsync(line.BrandId),
					CreatedBy= createdby
				};
				nonCatalog.Lines.Add(nonCatalogLine);
			}
			
			return await nnc.CreateNonCatalogHeadAsync(nonCatalog);

		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}