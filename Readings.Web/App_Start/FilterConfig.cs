using System.Web;
using System.Web.Mvc;
using StackExchange.Profiling.Mvc;

namespace Readings.Web {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ProfilingActionFilter());
        }
    }
}
