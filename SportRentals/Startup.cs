using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportRentals.Startup))]
namespace SportRentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
