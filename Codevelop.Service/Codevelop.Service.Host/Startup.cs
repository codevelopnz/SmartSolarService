using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Codevelop.Service.Host.Startup))]
namespace Codevelop.Service.Host
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
