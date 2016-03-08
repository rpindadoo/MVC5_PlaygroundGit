using System.Globalization;
using System.Web.Optimization;

namespace Sample.Web{
    public static class BundleConfig{
        public static void RegisterBundles(BundleCollection bundles){
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/legacybrowsers").Include(
                "~/Scripts/respond.js",
                "~/Scripts/html5shiv.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/jquery.signalR-2.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                "~/Scripts/Shared/modal.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css"));


#if !DEBUG 
              BundleTable.EnableOptimizations = true;
#endif
        }
    }
}