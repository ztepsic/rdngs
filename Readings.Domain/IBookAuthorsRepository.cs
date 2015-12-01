using System.Collections.Generic;
using Zed.Domain;

namespace Readings.Domain {
    /// <summary>
    /// Book authors repository
    /// </summary>
    public interface IBookAuthorsRepository : IReadOnlyRepository<BookAuthor> {
        /// <summary>
        /// Gets total number of book authors
        /// </summary>
        /// <param name="firstSurnameLetter">first surname letter of book author</param>
        /// <returns>Total number of book authors</returns>
        int GetTotalNumberOfBookAuthors(string firstSurnameLetter = null);

        /// <summary>
        /// Gets book authors
        /// </summary>
        /// <param name="limit">Max number of book authors to fetch</param>
        /// <param name="offset">Offset</param>
        /// <returns></returns>
        IEnumerable<BookAuthor> GetAuthors(int limit, int offset);
    }
}
