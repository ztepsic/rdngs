using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;

namespace Readings.Web {
    public class MvcApplication : System.Web.HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //MiniProfiler.Settings.Results_List_Authorize = (httpRequest) => true;

            var ignoredPaths = MiniProfiler.Settings.IgnoredPaths.ToList();
            ignoredPaths.Add("/__browserLink/");
            MiniProfiler.Settings.IgnoredPaths = ignoredPaths.ToArray();

            //var copy = ViewEngines.Engines.ToList();
            //ViewEngines.Engines.Clear();
            //foreach (var item in copy) {
            //    ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            //}
            

        }

        protected void Application_BeginRequest() {
            //enableProfiling = bool.Parse(ConfigurationManager.AppSettings["miniprofiler.enable_profiling"]);
            if (Request.IsLocal) {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest() {
            MiniProfiler.Stop();
        }

    }
}
