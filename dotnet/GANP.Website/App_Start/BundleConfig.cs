using System.Web;
using System.Web.Optimization;

namespace GANP.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/content/5grid/core.css",
                        "~/content/5grid/core-desktop.css",
                        "~/content/5grid/core-1200px.css",
                        "~/content/5grid/core-noscript.css",
                        "~/content/style.css",
                        "~/content/style-desktop.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/content/5grid/jquery.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
