using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOFEMVC.Startup))]
namespace SOFEMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
