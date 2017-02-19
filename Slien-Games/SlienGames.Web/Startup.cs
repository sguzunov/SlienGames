using Microsoft.AspNet.SignalR;
using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(SlienGames.Web.Startup))]
namespace SlienGames.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var config = new HubConfiguration
            {
                Resolver = GlobalHost.DependencyResolver
            };
            this.ConfigureSignalR(app, config);
        }

        private void ConfigureSignalR(IAppBuilder app, HubConfiguration config)
        {
            app.MapSignalR(config);
        }
    }
}
