using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Readings.Web.Startup))]
namespace Readings.Web {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            
        }
    }
}
