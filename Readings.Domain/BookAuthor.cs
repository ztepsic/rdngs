namespace Readings.Domain {
    /// <summary>
    /// Represents a book author
    /// </summary>
    public class BookAuthor {

        #region Fields and Properties

        /// <summary>
        /// Book author name
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Gets book author name
        /// </summary>
        public string Name { get { return name; } }


        /// <summary>
        /// Book author surname
        /// </summary>
        private readonly string surname;

        /// <summary>
        /// Gets book author surname
        /// </summary>
        public string Surname { get { return surname; } }

        #endregion

        #region Constructors and

        /// <summary>
        /// Creates a book author
        /// </summary>
        /// <param name="name">Book author name</param>
        /// <param name="surname">Book author surname</param>
        public BookAuthor(string name, string surname) {
            this.name = name;
            this.surname = surname;
        }

        #endregion

        #region Methods

        #endregion

    }
}
