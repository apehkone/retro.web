using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Retro.Web;

[assembly: OwinStartup(typeof (Startup))]

namespace Retro.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR(new HubConfiguration() {EnableDetailedErrors = true});
            ConfigureAuth(app);
        }
    }
}