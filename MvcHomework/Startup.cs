using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcHomework.Startup))]
namespace MvcHomework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
