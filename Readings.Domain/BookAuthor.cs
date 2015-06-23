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
        private readonly string surname;

        /// <summary>
        /// Gets book author surname
        /// </summary>
        public string Surname { get { return surname; } }

        /// <summary>
        /// Gets or Sets author's biography
        /// </summary>
        public string Biography { get; set; }

        #endregion

        #region Constructors and

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
