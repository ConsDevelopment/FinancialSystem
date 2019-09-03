using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Host.SystemWeb;

//[assembly: PreApplicationStartMethod(typeof(PreApplicationStart), "Initialize")]
[assembly:OwinStartup(typeof(FinancialSystem.Startup))]
namespace FinancialSystem {
	public class Startup {
		public void Configuration(IAppBuilder app) {
			app.UseCookieAuthentication(new CookieAuthenticationOptions {
				AuthenticationType = "ApplictionCookie",
				LoginPath = new PathString("/User/Login")
			});
		}
	}
}