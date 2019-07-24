using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoRentalSystem.Startup))]
namespace VideoRentalSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
