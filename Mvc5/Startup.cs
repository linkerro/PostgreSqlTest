using Microsoft.Owin;
using Mvc5;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
