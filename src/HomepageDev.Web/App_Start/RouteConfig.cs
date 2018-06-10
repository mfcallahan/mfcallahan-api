using System.Web.Mvc;
using System.Web.Routing;

namespace HomepageDev.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // mfcallahan-dev.com/ADOT
            routes.MapRoute(
                name: "ADOT",
                url: "ADOT",
                defaults: new { controller = "Home", action = "ADOT" }
            );

            // homepage root: mfcallahan-dev.com
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    namespaces: new[] { "HomepageDev.Web.Controllers" }
            //);
        }
    }
}
