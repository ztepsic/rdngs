using System.Web.Mvc;

namespace Readings.Web.Controllers {
    /// <summary>
    /// Books and readings controller
    /// </summary>
    public class ReadingsController : Controller {

        // TODO
        // GET: Readings
        public ActionResult Index() {
            return View();
        }

        /// <summary>
        /// Prepares book page
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <param name="bookTitleSlug">Book title slug</param>
        /// <returns>Detail book view</returns>
        public ActionResult Book(int bookId, string bookTitleSlug) {
            return View();
        }

        /// <summary>
        /// Prepares reading for a book
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <param name="bookTitleSlug">Book title slug</param>
        /// <param name="readingVersion">Reading version</param>
        /// <returns>Detail reading view</returns>
        public ActionResult Reading(int bookId, string bookTitleSlug, string readingVersion) {
            return View();
        }

    }
}