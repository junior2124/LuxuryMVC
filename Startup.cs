using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuxuryMVC.Startup))]
namespace LuxuryMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
