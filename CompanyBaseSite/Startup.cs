using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyBaseSite.Startup))]
namespace CompanyBaseSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
