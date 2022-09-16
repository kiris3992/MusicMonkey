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

[assembly: OwinStartupAttribute(typeof(MusicMonkeyWebApp.Startup))]
namespace MusicMonkeyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                //Admin Role  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Admin User                   

                var user = new ApplicationUser();
                user.UserName = "musicMonkey@hotmail.com";
                user.Email = "musicMonkey@hotmail.com";
                string userPWD = "Mus1cM@nkey";

                var chkUser = UserManager.Create(user, userPWD);

                //Add User to Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Gold(Subscriber) role     
            if (!roleManager.RoleExists("Gold"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Gold";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "orestaras@hotmail.com";
                user.Email = "orestaras@hotmail.com";
                string usePWD = "Mus1cM@nkey";

                var chkUser = UserManager.Create(user, usePWD);
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Gold");
                }
            }

            // creating Creating Silver(Normal User) role  
            if (!roleManager.RoleExists("Silver"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Silver";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "linos@hotmail.com";
                user.Email = "linos@hotmail.com";
                string usePWD = "Mus1cM@nkey";

                var chkUser = UserManager.Create(user, usePWD);
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Silver");
                }
            }
        }
    }
}
