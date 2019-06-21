using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PT.Startup))]
namespace PT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
