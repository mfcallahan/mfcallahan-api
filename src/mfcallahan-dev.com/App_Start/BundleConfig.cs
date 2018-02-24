using System.Web.Optimization;

namespace HomepageDev
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // site styles
            bundles.Add(new StyleBundle("~/Content/style-site").Include(
                "~/Content/bootstrap.min.css"));

            // site scripts
            bundles.Add(new ScriptBundle("~/bundles/scripts-site").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/bootstrap.min.js"));            
        }
    }
}