using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Runner.Startup))]
namespace Runner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
