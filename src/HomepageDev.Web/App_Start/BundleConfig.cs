using System.Web.Optimization;

namespace HomepageDev.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;

            // site styles
            bundles.Add(new StyleBundle("~/bundles/css-site").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/Home/css/site.css"));

            // site scripts
            bundles.Add(new ScriptBundle("~/bundles/js-site").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/bootstrap.min.js",
                "~/Content/Home/js/site.js"));

            // ADOT scripts          
            bundles.Add(new ScriptBundle("~/bundles/js-adot").Include(
                "~/Content/ADOT/js/adot.js"));

            // Map scripts          
            //bundles.Add(new StyleBundle("~/bundles/css-map").Include(
            //    "~/Content/Map/css/map.css"));

            //bundles.Add(new ScriptBundle("~/bundles/js-map").Include(
            //    "~/Content/Map/js/map.js"));

            // leaflet.js
            //bundles.Add(new StyleBundle("~/bundles/css-leaflet", "https://unpkg.com/leaflet@1.3.1/dist/leaflet.css").Include(
            //    "~/Content/Map/css/leaflet.css"));
            //bundles.Add(new ScriptBundle("~/bundles/js-leaflet", "https://unpkg.com/leaflet@1.3.1/dist/leaflet.js").Include(
            //    "~/Content/Map/js/leaflet.js"));
        }
    }
}