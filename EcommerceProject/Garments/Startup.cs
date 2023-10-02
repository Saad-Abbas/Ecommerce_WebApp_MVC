using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Garments.Startup))]
namespace Garments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
