using System.Collections.Generic;
using System.Linq;
using Dapper;
using Readings.Domain;
using Zed.Data;

namespace Readings.Infrastructure.DataAccess {
    /// <summary>
    /// Book authors Dapper repository
    /// </summary>
    public class BookAuthorsDpRepository
        : AdoNetRepository, IBookAuthorsRepository {

        #region Fields and Properties

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Creates an instance of book authors repository
        /// </summary>
        /// <param name="dbConnectionFactory">Database connection factory</param>
        public BookAuthorsDpRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all persisted BookAuthor entities/aggregare roots
        /// ordered by identifier.
        /// </summary>
        /// <returns>BookAuthors ordered by identifier.</returns>
        public IEnumerable<BookAuthor> GetAll() {
            return DbConnection.Query<BookAuthor>(@"
                        select *
                        from BookAuthors
                        order by Id;
                        ");
        }

        /// <summary>
        /// Gets BookAuthor entity/aggregate root based on it's identity
        /// </summary>
        /// <param name="id">Entitiy/Aggregare root identifier</param>
        /// <returns>BookAuthor entity/aggregare root</returns>
        public BookAuthor GetById(int id) {
            var querySql = @"
                select *
                from BookAuthors
                where id = @BookAuthorId;

                with Result as (
                    select *
                    from ArticleSections
                    where Id = @BookAuthorId
                    union all
                    select resultPlus1.*
                    from ArticleSections as ResultPlus1
                    join Result on
                        Result.Id = ResultPlus1.ParentId
                )
                select *
                from Result
                order by Level, [Order];
            ";

            BookAuthor bookAuthor = null;
            using (var multi = DbConnection.QueryMultiple(querySql, new { BookAuthorId = id }, DbConnection.Transaction)) {
               bookAuthor = multi.Read<BookAuthor>().Single();
               var articleSections = multi.Read<ArticleSection>().ToList();
                foreach (var articleSection in articleSections) {
                    if (bookAuthor.Article == null) {
                        bookAuthor.Article = articleSection;
                    } else {
                        
                    }
                }
            }

            //return DbConnection.Query<BookAuthor>(
            //    querySql,
            //    new {BookAuthorId = id},
            //    DbConnection.Transaction
            //).FirstOrDefault();

            return bookAuthor;
        }

        #endregion

    }
}
