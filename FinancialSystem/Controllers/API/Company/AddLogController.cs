using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinancialSystem.Controllers.API.Company {
	public class AddLogController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id) {
			return "value";
		}

		// POST api/<controller>
		public string Post() {
			//var provider = new MultipartMemoryStreamProvider();
			//await Request.Content.ReadAsMultipartAsync(provider);

			//// extract file name and file contents
			//var fileNameParam = provider.Contents[0].Headers.ContentDisposition.Parameters
			//	.FirstOrDefault(p => p.Name.ToLower() == "filename");
			//string fileName = (fileNameParam == null) ? "" : fileNameParam.Value.Trim('"');

			//byte[] file = await provider.Contents[0].ReadAsByteArrayAsync();

			//// Here you can use EF with an entity with a byte[] property, or
			//// an stored procedure with a varbinary parameter to insert the
			//// data into the DB

			//var result
			//	= string.Format("Received '{0}' with length: {1}", fileName, file.Length);
			//return result;

			HttpResponseMessage result = null;
			var httpRequest = HttpContext.Current.Request;
			
			if (httpRequest.Files.Count > 0) {
				var docfiles = new List<string>();
				foreach (string file in httpRequest.Files) {
					var postedFile = httpRequest.Files[file];
					var extension = System.IO.Path.GetExtension(postedFile.FileName);
					var finame = Guid.NewGuid();
					var filePath = HttpContext.Current.Server.MapPath("~/Content/images/" + finame + extension);
					postedFile.SaveAs(filePath);
					docfiles.Add(filePath);
				}
				result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
			} else {
				result = Request.CreateResponse(HttpStatusCode.BadRequest);
			}
			return result.ReasonPhrase;
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}