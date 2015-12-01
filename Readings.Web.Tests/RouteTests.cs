using System.Web.Routing;
using NUnit.Framework;
using Zed.Web.Test;

namespace Readings.Web.Tests {
    [TestFixture]
    public class RouteTests {

        private RouteCollection routes;

        [SetUp]
        public void SetUp() {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
        }


        #region BookAuthorsController

        [Test]
        public void BookAuthorsControllerRoutes() {
            // Arrange
            const string supportedUrl1 = "~/pisci/";
            const string supportedUrl2 = "~/pisci/stranica/23";

            const string notSupportedUrl1 = "~/pisci/stranica/0";
            const string notSupportedUrl2 = "~/pisci/stranica/";
            const string notSupportedUrl3 = "~/pisci/stranica/A";

            // Act

            // Assert
            Assert.IsTrue(RouteTest.RouteMatch(supportedUrl1, routes, "Index", "BookAuthors"));
            Assert.IsTrue(RouteTest.RouteMatch(supportedUrl2, routes, "Index", "BookAuthors", new { page = 23}));


            Assert.IsFalse(RouteTest.RouteMatch(notSupportedUrl1, routes, "Index", "BookAuthors", new { page = 0 }));
            Assert.IsFalse(RouteTest.RouteMatch(notSupportedUrl2, routes, "Index", "BookAuthors"));
            Assert.IsFalse(RouteTest.RouteMatch(notSupportedUrl3, routes, "Index", "BookAuthors", new { page = "A" }));
        }

        #endregion

    }
}
