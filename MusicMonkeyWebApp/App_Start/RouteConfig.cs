using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicMonkeyWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //AreaRegistration.RegisterAllAreas();


            // OK
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "MusicMonkeyWebApp.Controllers" }
            );



            //routes.MapRoute(
            //    "Default",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "MusicMonkeyWebApp.Areas.Public.Controllers" }
            //);

            //context.MapRoute(
            //    "Public_default",
            //    "Public/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new[] { "MusicMonkeyWebApp.Areas.Public.Controllers" }
            //);

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //context.MapRoute(
            //    "Public_default",
            //    "Public/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //); 

            //routes.MapRoute(
            //    "Home_Default2",
            //    "Home/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);



            //C:\Users\kiris3992\Desktop\Lessons\Lessons\Ektoras\12.07.2022\Design Patters\MusicMonkey\MusicMonkeyWebApp\Areas\Public\Views\Home\
            //C:\Users\kiris3992\Desktop\Lessons\Lessons\Ektoras\12.07.2022\Design Patters\MusicMonkey\MusicMonkeyWebApp\Areas\
            //routes.MapRoute(
            //   "ApiControllerOne", // Name of folder
            //    "ApiControllerOne/{controller}/{action}/{id}",
            //    new { controller = "ApiFactory", action = "callFactoryOne", id = UrlParameter.Optional },
            //    new string[] { "mvcPartialView.ApiControllerOne" } // Namespace
            //);

            //url: "AnotherNameThatPointsToHome/{action}/{id}",

            //new [] { "MusicMonkeyWebApp.Areas.Controllers" }
        }

        
    }
}
