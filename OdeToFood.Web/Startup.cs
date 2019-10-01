using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OdeToFood.Web.Startup))]
namespace OdeToFood.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
