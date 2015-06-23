using System.Web.Mvc;

namespace Readings.Web.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            return View();
        }
    }
}