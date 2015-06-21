using System;
using Zed.Domain;

namespace Readings.Domain {
    /// <summary>
    /// Represents a book
    /// </summary>
    public class Book : Entity {

        #region Fields and Properties

        /// <summary>
        /// Book title
        /// </summary>
        private readonly string title;

        /// <summary>
        /// Gets book title
        /// </summary>
        public string Title { get { return title; } }

        /// <summary>
        /// Book description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date when book was added in UTC.
        /// </summary>
        private readonly DateTime addedOn;

        /// <summary>
        /// Gets the date when the book was added in UTC.
        /// </summary>
        public DateTime AddedOn { get { return addedOn; } }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates book
        /// </summary>
        /// <param name="title">Book title</param>
        public Book(string title) {
            this.title = title;

            addedOn = DateTime.UtcNow;
        }

        #endregion

        #region Methods

        #endregion

    }
}
