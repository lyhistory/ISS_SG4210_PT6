using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CR_PL.Startup))]
namespace CR_PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
