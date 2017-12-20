using System.Web;
using System.Web.Optimization;

namespace resource_dashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                      "~/Scripts/respond.js,"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/ng-tags-input.js",
                    "~/app/app.js",
                    "~/app/app-config.js")
                .IncludeDirectory("~/app/controllers", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ng-tags-input.css",
                      "~/Content/site.css"));
        }
    }
}
