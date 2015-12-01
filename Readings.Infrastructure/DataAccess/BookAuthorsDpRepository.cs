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
        /// Gets total number of book authors
        /// </summary>
        /// <param name="firstSurnameLetter">first suname letter of book author</param>
        /// <returns>Total number of book authors</returns>
        public int GetTotalNumberOfBookAuthors(string firstSurnameLetter = null) {
            var query = @"
                select count(*) totalNumberOfBookAuthors
                from BookAuthors
            ";

            if (!string.IsNullOrEmpty(firstSurnameLetter)) {
                query += "where Surname like '@FirstSurnameLetter%';";
            }

            return DbConnection.Query<int>(query, new { FirstSurnameLetter = firstSurnameLetter }, DbConnection.Transaction)
                .SingleOrDefault();
        }

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
                 ", null, DbConnection.Transaction);
        }


        /// <summary>
        /// Gets book authors
        /// </summary>
        /// <param name="limit">Max number of book authors to fetch</param>
        /// <param name="offset">Offset</param>
        /// <returns>BookAuthors ordered by surname</returns>
        public IEnumerable<BookAuthor> GetAuthors(int limit, int offset) {
            return DbConnection.Query<BookAuthor>(@"
                        select *
                        from BookAuthors
                        order by Surname
                        offset @Offset rows
                        fetch next @Limit rows only
                        ;
                 ", new { @Offset = offset, @Limit = limit }, DbConnection.Transaction);
        }

        /// <summary>
        /// Gets BookAuthor entity/aggregate root based on it's identity
        /// </summary>
        /// <param name="id">Entitiy/Aggregare root identifier</param>
        /// <returns>BookAuthor entity/aggregare root</returns>
        public BookAuthor GetById(int id) {
            const string querySql = @"
                select *
                from BookAuthors
                where id = @BookAuthorId;

                with ArticleSectionItems as (
                    select *
                    from ArticleSections
                    where Id = (select BiographyRootArticleSectionId
                                from BookAuthors
                                where id = @BookAuthorId)
                    union all
                    select resultPlus1.*
                    from ArticleSections as ResultPlus1
                    join ArticleSectionItems on
                        ArticleSectionItems.Id = ResultPlus1.ParentId
                )
                select Child.*
                from ArticleSectionItems Child
                left join ArticleSections Parent on
                    Parent.Id = Child.ParentId
                order by Parent.level, Parent.[order], Child.Level, Child.[Order];
            ";


            BookAuthor bookAuthor = null;
            using (var multi = DbConnection.QueryMultiple(querySql, new { BookAuthorId = id }, DbConnection.Transaction)) {
                bookAuthor = multi.Read<BookAuthor>().Single();
                var articleSectionsDict = multi.Read<ArticleSection>().ToDictionary(x => x.Id);

                foreach (var articleSectionItem in articleSectionsDict) {
                    var articleSection = articleSectionItem.Value;
                    if (bookAuthor.Article == null && articleSection.ParentId == null) {
                        bookAuthor.Article = articleSectionItem.Value;
                    } else {
                        articleSection.MoveToParent(articleSectionsDict[articleSection.ParentId ?? -1]);
                    }
                }
            }

            return bookAuthor;
        }

        #endregion

    }
}
