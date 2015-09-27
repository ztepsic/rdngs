using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Readings.Domain;
using Readings.Infrastructure.DataAccess;
using StackExchange.Profiling;
using Zed.Data;
using Zed.Transaction;
using Zed.Web.Transaction;

namespace Readings.Web.App_Start {
    public class ReadingsNinjectModule : NinjectModule {
        public override void Load() {
            var connectionString = ConfigurationManager.ConnectionStrings["ReadingsDb"].ConnectionString;
            var dbConnectionFactory = new DbConnectionFactory(() => {
                var dbConnection = new SqlConnection(connectionString);
                if (MiniProfiler.Current != null) {
                    return new StackExchange.Profiling.Data.ProfiledDbConnection(dbConnection, MiniProfiler.Current);
                }

                return dbConnection;
            });

            Bind<IDbConnectionFactory>().ToConstant(dbConnectionFactory);
            Bind<IUnitOfWork>().To<AdoNetUnitOfWork>().InRequestScope();
            this.BindFilter<UnitOfWorkFilter>(FilterScope.Action, UnitOfWorkFilter.ORDER_OF_FILTER_IN_STACK_OF_FILTERS)
                .WhenActionMethodHas<UnitOfWorkAttribute>()
                //.WithConstructorArgumentFromActionAttribute<UnitOfWorkAttribue>("unitOfWork", a => a.Prefix)
            ;

            Bind<IBookAuthorsRepository>().To<BookAuthorsDpRepository>().InRequestScope();

        }
    }
}