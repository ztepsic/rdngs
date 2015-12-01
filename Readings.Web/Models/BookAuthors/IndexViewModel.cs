using System.Collections.Generic;
using PagedList;
using Readings.Domain;
using Zed.Web.Models;

namespace Readings.Web.Models.BookAuthors {
    public class IndexViewModel {

        #region Fields and Properties

        public PageInfoModel PageInfoModel { get; set; }

        public IPagedList<BookAuthor> BookAuthors { get; set; }

        #endregion

        #region Constructors and Init
        #endregion

        #region Methods
        #endregion

    }
}