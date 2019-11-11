
using System.Web.Optimization;
using FinancialSystem.Utilities;


namespace FinancialSystem
{
	public class BundleConfig {

		private static Bundle UpdateMinification(Bundle scripts) {
			if (Config.DisableMinification()) {
				scripts.Transforms.Clear();
			}
			return scripts;
		}


		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {

            //JQuery(bundles);
            //Bootstrap(bundles);
            //Compatability(bundles);
            //Main(bundles);
            registration(bundles);
            login(bundles);
			PR(bundles);
			ReviewPR(bundles);
			PRCreation(bundles);
			Utilities(bundles);
			PRAprover(bundles);
			QuoteAnalysis(bundles);
			PRSearch(bundles);
			POSearch(bundles);
			AddNewItems(bundles);
			BundleTable.EnableOptimizations = Config.OptimizationEnabled();

		}


		//private static void Compatability(BundleCollection bundles) {
		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/compatability").Include(
		//			  "~/Scripts/Main/iefixes.js"
		//	)));
		//}

		//private static void Main(BundleCollection bundles) {

		//	var list = new List<string>() {
		//		"~/Scripts/Main/time.js",
		//		"~/Scripts/Main/linq.js",
		//		"~/Scripts/Main/radial.js",
		//		"~/Scripts/Main/modals.js",
		//		"~/Scripts/Main/datepickers.js",
		//		"~/Scripts/Main/support.js",
		//		"~/Scripts/Main/backwardcompatability.js",
		//		"~/Scripts/Main/ajaxintercepters.js",
		//		"~/Scripts/Main/datatable.js",
		//		"~/Scripts/Main/tours.js",
		//		"~/Scripts/Main/alerts.js",
		//		"~/Scripts/Main/clickableclass.js",
		//		"~/Scripts/Main/profilepicture.js",
		//		"~/Scripts/Main/libraries.js",
		//		"~/Scripts/Main/chart.js",
		//		"~/Scripts/Main/realtime.js",
		//	};


		//	//Only intercept logs if not local...
		//	if (Config.GetEnv() != Env.local_mysql)
		//		list.Add("~/Scripts/Main/log-helper.js");

		//	list.AddRange(new[] {
  //              /*"~/Scripts/jquery.signalR-{version}.js",Was deleted*/
  //              "~/Scripts/jquery/jquery.tablesorter.js",
		//		"~/Scripts/Main/finally.js",
		//		"~/Scripts/Main/intercom.min.js",
		//		"~/Scripts/L10/jquery-ui.color.js",
		//		"~/Scripts/jquery/jquery.tabbable.js",
		//		"~/Scripts/components/milestones.js",
		//		"~/Scripts/Main/keyboard.js",
		//		"~/Scripts/Main/tooltips.js",
		//		"~/Scripts/Main/beta.js"
		//	});

		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/main").Include(list.ToArray())));

		//}


		

		

		

		private static void registration(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/User/registration")
				.Include("~/Content/User/registration.css"));
			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/user/Registration").Include(
					 "~/scripts/user/Registration.js"
		   )));
		}
        private static void login(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/User/login")
                .Include("~/Content/User/login.css"));
            bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/user/Login").Include(
                      "~/scripts/user/Login.js"
            )));
        }
		private static void PR(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PR/pr-shop")
				.Include("~/Content/PR/pr-shop.css"));
			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/PR/PR").Include(
					 "~/scripts/PR/PR.js"
		   )));

		}
		private static void Utilities(BundleCollection bundles) {

			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/Utilities/Utilities").Include(
					 "~/scripts/Utilities/Utilities.js"
		   )));

		}
		private static void ReviewPR(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PR/Review")
				.Include("~/Content/PR/review.css"));

		}
		private static void PRCreation(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PR/PRCreation")
				.Include("~/Content/PR/PRCreation.css"));

		}
		private static void PRAprover(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PR/PRAprover")
				.Include("~/Content/PR/pr-approver.css"));
			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/PR/PRApproved").Include(
					 "~/scripts/PR/PRApproved.js"
		   )));

		}
		private static void QuoteAnalysis(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PR/quote-analysis")
				.Include("~/Content/PR/quote-analysis.css"));
			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/PR/QuoteAnalysis").Include(
					 "~/scripts/PR/QuoteAnalysis.js"
			  )));
		}
		private static void PRSearch(BundleCollection bundles) {

			bundles.Add(new StyleBundle("~/Content/PO/po-creation")
				.Include("~/Content/PO/po-creation.css"));
			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/PO/PRSearch").Include(
					 "~/scripts/PO/PRSearch.js"
			  )));

		}
		private static void POSearch(BundleCollection bundles) {

			bundles.Add(UpdateMinification(new ScriptBundle("~/scripts/PO/POSearch").Include(
					 "~/scripts/PO/POSearch.js"
			  )));

		}


		private static void AddNewItems(BundleCollection bundles) {

            bundles.Add(new StyleBundle("~/Content/Maintenance/add-items")
                .Include("~/Content/Maintenance/add-items.css"));

        }

		//private static void Bootstrap(BundleCollection bundles) {
		//	// Use the development version of Modernizr to develop with and learn from. Then, when you're
		//	// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
		//	//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
		//	//			"~/Scripts/modernizr-*"));

		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/bootstrap").Include(
		//			  "~/Scripts/components/posneg.js",
		//			  "~/Scripts/components/tristate.js",
		//			  "~/Scripts/components/fivestate.js",
		//			  "~/Scripts/components/checktree.js",
		//			  "~/Scripts/components/rockstate.js",
		//			  "~/Scripts/components/approvereject.js",
		//			  "~/Scripts/components/completeincomplete.js",
		//			  "~/Scripts/select2.min.js",
		//			  "~/Scripts/bootstrap.js",
		//			  "~/Scripts/respond.js",
		//			  "~/Scripts/bootstrap-slider.js",
		//			  "~/Scripts/bootstrap-datepicker.js")));

		//	bundles.Add(new StyleBundle("~/Content/css").Include(
		//			"~/Content/components/posneg.css",
		//			"~/Content/components/tristate.css",
		//			"~/Content/components/fivestate.css",
		//			"~/Content/components/table.css",
		//			"~/Content/components/checktree.css",
		//			"~/Content/components/rockstate.css",
		//			"~/Content/components/approvereject.css",
		//			"~/Content/components/CompleteIncomplete.css",
		//			"~/Content/select2-bootstrap.css",
		//			"~/Content/select2.css",
		//			"~/Content/datepicker.css",
		//			"~/Content/bootstrap/bootstrap.css",
		//			//"~/Content/Bootstrap-tabs.css",
		//			"~/Content/bootstrap.vertical-tabs.css",
		//			"~/Content/slider.css",
		//			"~/Content/site.css",
		//			"~/Content/bootstrap/custom/Site.css",
		//			"~/Content/Fonts.css",
		//			"~/Content/jquery.qtip.css"));
		//}

		//private static void JQuery(BundleCollection bundles) {
		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/jquery")
		//					.Include("~/Scripts/jquery-{version}.js")
		//					.Include("~/Scripts/jquery.unobtrusive-ajax.js")
		//					.Include("~/Scripts/jquery/jquery.qtip.js")
		//					//.Include("~/Scripts/jquery/jquery.attrchange.js")
		//					));

		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/animations")
		//		.Include("~/Scripts/animations/*.js")
		//		.Include("~/Scripts/jquery/*.js")
		//		));

		//	bundles.Add(UpdateMinification(new ScriptBundle("~/bundles/jqueryval").Include(
		//				"~/Scripts/jquery.validate*")));
		//}

	}
}
