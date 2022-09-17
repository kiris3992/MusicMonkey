using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MusicMonkeyWebApp.Models;
using Owin;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Linq;
using System.Data;
using System.Security.Policy;
using System.Net;
using MusicMonkeyWebApp.App_Start;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(MusicMonkeyWebApp.Startup))]
namespace MusicMonkeyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //if (WebSetsConfig.Initialize()) return;
            ConfigureAuth(app);
            //UsersConfig.SeedUsers();
            app.MapSignalR();
        }
    }

    
}
