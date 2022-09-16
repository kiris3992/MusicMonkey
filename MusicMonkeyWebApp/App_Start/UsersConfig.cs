using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicMonkeyWebApp.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;

namespace MusicMonkeyWebApp.App_Start
{
    public class UsersConfig
    {
        public static void SeedUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string[] roles = { "Admin", "Gold", "Silver" };

            List<(string role, string name, string mail, string pass)> users;
            users = new List<(string role, string name, string mail, string pass)>
            {
                ("Admin", "musicMonkey@hotmail.com", "musicMonkey@hotmail.com", "Mus1cM@nkey"),
                ("Gold", "orestaras@hotmail.com", "orestaras@hotmail.com", "Mus1cM@nkey"),
                ("Silver", "linos@hotmail.com", "linos@hotmail.com", "Mus1cM@nkey"),
            };

            roles.ForEach(role =>
            {
                if (roleManager.RoleExists(role)) return;
                roleManager.Create(new IdentityRole { Name = role });
            });

            users.ForEach(user =>
            {
                if (UserManager.FindByName(user.name) != null) return;

                var appUser = new ApplicationUser { UserName = user.name, Email = user.mail };

                if (UserManager.Create(appUser, user.pass).Succeeded)
                {
                    UserManager.AddToRole(appUser.Id, user.role);
                }
            });
        }
    }
}