using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeStoreWeb.Startup))]
namespace LeStoreWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
