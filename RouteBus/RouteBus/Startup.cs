using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RouteBus.Startup))]
namespace RouteBus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
