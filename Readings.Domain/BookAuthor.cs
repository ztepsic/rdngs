using System;
using Zed.Domain;

namespace Readings.Domain {
    /// <summary>
    /// Represents a book author
    /// </summary>
    public class BookAuthor : Entity {

        #region Fields and Properties

        /// <summary>
        /// Gets or Sets book author name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Book author surname
        /// </summary>
        private string surname;

        /// <summary>
        /// Gets book author surname
        /// </summary>
        public string Surname { get { return surname; } }

        /// <summary>
        /// Gets book author full name
        /// </summary>
        public string FullName { get { return String.Format("{0} {1}", Name, Surname); } }

        /// <summary>
        /// Gets or Sets author's short biography
        /// </summary>
        public string ShortBiography { get; set; }

        /// <summary>
        /// Book author biography source name
        /// </summary>
        public string BiographySrcName { get; set; }

        /// <summary>
        /// Book author biography source url
        /// </summary>
        public string BiographySrcUrl { get; set; }

        /// <summary>
        /// Article
        /// </summary>
        public ArticleSection Article { get; set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor that creates a new instance of BookAuthor class.
        /// </summary>
        private BookAuthor() { }

        /// <summary>
        /// Creates a book author
        /// </summary>
        /// <param name="surname">Book author surname</param>
        public BookAuthor(string surname) {
            this.surname = surname;
        }

        /// <summary>
        /// Creates a book author
        /// </summary>
        /// <param name="name">Book author name</param>
        /// <param name="surname">Book author surname</param>
        public BookAuthor(string name, string surname) {
            Name = name;
            this.surname = surname;
        }

        #endregion

        #region Methods

        #endregion

    }
}
