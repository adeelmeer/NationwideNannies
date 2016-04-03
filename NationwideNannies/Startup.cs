using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NationwideNannies.Startup))]
namespace NationwideNannies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
