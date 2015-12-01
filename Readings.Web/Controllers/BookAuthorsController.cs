using System;
using System.Web.Mvc;
using PagedList;
using Readings.Domain;
using Readings.Web.Models.BookAuthors;
using StackExchange.Profiling;
using Zed.Web.Models;
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


        /// <summary>
        /// Gets book authors list
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>Book authors list view</returns>
        [UnitOfWork]
        public ActionResult Index(int page = 1) {
            var pageSize = 10;
            var totalBookAuthors = bookAuthorsRepository.GetTotalNumberOfBookAuthors();

            if (page > Decimal.Ceiling((decimal)totalBookAuthors/pageSize)) return new HttpNotFoundResult();

            var bookAuthors = bookAuthorsRepository.GetAuthors(pageSize, pageSize * (page - 1));

            var bookAuthorsPagedList = new StaticPagedList<BookAuthor>(bookAuthors, page, pageSize, totalBookAuthors);

            var indexViewModel = new IndexViewModel() {
                BookAuthors = bookAuthorsPagedList
            };

            return View("Index", indexViewModel);
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

            var model = new BookAuthorDetailsViewModel {
                BookAuthor = bookAuthor,
                PageInfoModel = new PageInfoModel(bookAuthor.FullName) {
                    Description = bookAuthor.ShortBiography
                }
            };

            model.PageInfoModel.AddKeyword(bookAuthor.FullName);

            return View(model);
        }

        #endregion

        #region Methods
        #endregion
    }
}