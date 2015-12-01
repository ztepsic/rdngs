using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Readings.Web {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BookAuthorsIndexWithPage",
                url: "pisci/stranica/{page}",
                defaults: new { controller = "BookAuthors", action = "Index" },
                constraints: new {
                    page = new CompoundRouteConstraint(new IRouteConstraint[] {
                        new IntRouteConstraint(),
                        new MinRouteConstraint(1)})
                }
            );

            routes.MapRoute(
                name: "BookAuthorsIndex",
                url: "pisci",
                defaults: new { controller = "BookAuthors", action = "Index", page = 1 }
            );

            routes.MapRoute(
                name: "BookAuthorsAuthorDetails",
                url: "pisac/{bookAuthorId}/{bookAuthorNameSlug}",
                defaults: new { controller = "BookAuthors", action = "AuthorDetails" }
            );

            routes.MapRoute(
                name: "ReadingsReading",
                url: "lektira/{bookId}/{bookTitleSlug}/{readingVersion}",
                defaults: new { controller = "Readings", action = "Reading" }
            );

            routes.MapRoute(
                name: "ReadingsBook",
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
