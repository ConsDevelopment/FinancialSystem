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

			var nhnch = new NHibernateNonCatalogStore();
			var user = new NHibernateUserStore();
			var nnc = new NHibernateNonCatalogStore();
			var supplierStore = new NHibernateISupplierStore();
			var subcategoryStore = new NHibernateCategoryStore();
			var company = new NHibernateCompanyStore();
			var createdby = await user.FindByStampAsync(value.SecurityStamp);

			var nonCatalog = await nnc.GetNonCatalogAsync(value.Id);

			if (nonCatalog == null) {
				nonCatalog = new NonCatalogItemHeadModel();					
			}
			nonCatalog.Name = value.Name;
			nonCatalog.Analysis = value.Analysis;
			nonCatalog.SubCategory = await subcategoryStore.FindSubCategoryByIdAsync(value.SubCategoryId);
			nonCatalog.Requestor = await company.GetEmployeeAsync(value.RequestorId);
			nonCatalog.CreatedBy = createdby;
			nonCatalog.Approver = await company.GetPositionByIdAsync(PurchaserHead);

			for(var line=0;line< nonCatalog.Lines.Count;line++) {
				if (!value.Lines.Any(x => x.Id == nonCatalog.Lines.ElementAt(line).Id)) {
					nonCatalog.Lines.ElementAt(line).DeleteTime = DateTime.UtcNow;
				}
			}
			foreach (var line in value.Lines) {
				if (nonCatalog.Lines.Any(x => x.Id == line.Id) && line.Id!=0) {
					continue;
				}
				var supplier = await supplierStore.FindSupplierByIdAsync(line.SupplierId);
				string tempSupplier = null;
				if (supplier == null) {
					tempSupplier = line.TempSupplier;
				}

				var nonCatalogLine = new NonCatalogItemLinesModel {
						Selected = line.Selected,
						Supplier = supplier,
						Price = line.Price,
						Description = line.Description,
						Quantity = line.Quantity,
						UOM = line.UOM,
						Discount = line.Discount,
						TotalAnount = line.TotalAnount,
						Availability = line.Availability,
						Terms = line.Terms,
						Brand = await supplierStore.FindBrandByIdAsync(line.BrandId),
						CreatedBy = createdby,
						TempSupplier = tempSupplier
				};
				nonCatalog.Lines.Add(nonCatalogLine);
				
			}
			if (value.Approved) {
				nonCatalog.ApprovedBy = createdby;
				nonCatalog.DateApproved = DateTime.UtcNow;
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