using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MITM.Startup))]
namespace MITM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
