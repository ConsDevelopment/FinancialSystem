using FinancialSystem.Utilities.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace FinancialSystem.Models.UserModels {
	public static class CurrentUserSession  {

		public static string userSecurityStampCookie {
			
		get {

				HttpCookie aCookie = HttpContext.Current.Request.Cookies["FSSecurityStamp"];
				if (aCookie != null) {
					return HttpContext.Current.Server.HtmlEncode(aCookie.Value);
				}
				return null;
			}
			set {
				HttpCookie SecurityStamp = new HttpCookie("FSSecurityStamp");
				SecurityStamp.Value = value;
				SecurityStamp.Expires = DateTime.UtcNow.AddDays(14);
				var response = HttpContext.Current.Response;

				response.Cookies.Remove("FSSecurityStamp");
				response.Cookies.Add(SecurityStamp);
			}
		}
		public static void removeSecurityStampCookie() {
			HttpCookie SecurityStamp = HttpContext.Current.Request.Cookies["FSSecurityStamp"];
			HttpContext.Current.Response.Cookies.Remove("FSSecurityStamp");
			if (SecurityStamp != null) {
				SecurityStamp.Expires = DateTime.UtcNow.AddDays(-10);
				SecurityStamp.Value = null;
				HttpContext.Current.Response.SetCookie(SecurityStamp);
			}
			
		}
		public static bool CloseUserSession() {
			var session = (SingleRequestSession)HttpContext.Current.Items["UserModel"];
			if (session != null) {
				if (session.IsOpen) {
					session.Close();

				}
				if (session.WasDisposed) {
					session.GetBackingSession().Dispose();
				}
				HttpContext.Current.Items.Remove("UserModel");
				return true;
			}
			return false;

		}
	}
}