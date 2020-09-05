using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaultTrage_Test2.Startup))]
namespace FaultTrage_Test2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
