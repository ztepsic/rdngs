using System.Web.Mvc;
using System.Web.Routing;

namespace Readings.Web {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Reading",
                url: "lektira/{bookId}/{bookTitleSlug}/{readingVersion}",
                defaults: new { controller = "Readings", action = "Reading" }
            );

            routes.MapRoute(
                name: "Book",
                url: "lektira/{bookId}/{bookTitleSlug}",
                defaults: new { controller = "Readings", action = "Book" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
