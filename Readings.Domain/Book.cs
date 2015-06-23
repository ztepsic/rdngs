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

        /// <summary>
        /// The date when the book was updated in UTC.
        /// </summary>
        private DateTime updatedOn;

        /// <summary>
        /// Gets the date when the book was updated in UTC
        /// </summary>
        public DateTime UpdatedOn { get { return UpdatedOn; } }

        /// <summary>
        /// An indicator that idicates if the book is published
        /// </summary>
        private bool published;

        /// <summary>
        /// Gets or Sets an indicator that indicates if the book is published
        /// </summary>
        public bool Published {
            get { return published; }
            set {
                published = value;
                setUpdatedOn();
            }
        }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates book
        /// </summary>
        /// <param name="title">Book title</param>
        public Book(string title) {
            this.title = title;

            addedOn = DateTime.UtcNow;
            updatedOn = addedOn;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the date when the book was updated in UTC.
        /// </summary>
        private void setUpdatedOn() {
            updatedOn = DateTime.UtcNow;
        }

        #endregion

    }
}
