using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicMonkeyWebApp.Startup))]
namespace MusicMonkeyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
