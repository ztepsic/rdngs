using System;
using System.Web.Mvc;
using Readings.Domain;
using StackExchange.Profiling;
using Zed.Web.Transaction;

namespace Readings.Web.Controllers {
    /// <summary>
    /// Book authors controller
    /// </summary>
    public class BookAuthorsController : Controller {

        #region Fields and Properties

        /// <summary>
        /// Book authors repository
        /// </summary>
        private readonly IBookAuthorsRepository bookAuthorsRepository;

        #endregion

        #region Constructors and init

        /// <summary>
        /// Created an instance of book authors controller
        /// </summary>
        /// <param name="bookAuthorsRepository">Book authors repository</param>
        public BookAuthorsController(IBookAuthorsRepository bookAuthorsRepository) {
            if (bookAuthorsRepository != null) {
                this.bookAuthorsRepository = bookAuthorsRepository;
            } else {
                throw new ArgumentNullException("bookAuthorsRepository");
            }
        }

        #endregion

        #region Actions


        // GET: BookAuthors
        public ActionResult Index() {
            return View();
        }


        /// <summary>
        /// Get book author's details
        /// </summary>
        /// <param name="bookAuthorId">Book author id</param>
        /// <param name="bookAuthorNameSlug">Book author name slug</param>
        /// <returns>Book author details</returns>
        [UnitOfWork]
        public ActionResult AuthorDetails(int bookAuthorId, string bookAuthorNameSlug) {
            var profiler = MiniProfiler.Current; // it's ok if this is null
            
            BookAuthor bookAuthor = null;
            using (profiler.Step("Query for book author")) {
                bookAuthor = bookAuthorsRepository.GetById(bookAuthorId);
            }

            return View(bookAuthor);
        }

        #endregion

        #region Methods
        #endregion
    }
}