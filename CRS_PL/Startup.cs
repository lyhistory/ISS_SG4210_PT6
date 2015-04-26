using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nus.iss.crs.pl.Startup))]
namespace nus.iss.crs.pl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
