using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMonkeyWebApp.App_Start
{
    public class WebSetsConfig
    {
        public static void Initialize()
        {
            var webConfig = new KirisMvcHelper.AppConfiguration();

            webConfig.MapItem("kiris", "MainDbConnection", "Data Source", @".\SQLEXPRESS");
            webConfig.MapItem("kiris", "DefaultConnection", "Data Source", @".\SQLEXPRESS");


            webConfig.MapItem("DESKTOP-G8HPF1S", "MainDbConnection", "Data Source", @"DESKTOP-G8HPF1S");
            webConfig.MapItem("DESKTOP-G8HPF1S", "DefaultConnection", "Data Source", @"DESKTOP-G8HPF1S");

            webConfig.MapItem("DESKTOP-7PDSP1R", "MainDbConnection", "Data Source", @"DESKTOP-7PDSP1R\SQLEXPRESS");
            webConfig.MapItem("DESKTOP-7PDSP1R", "DefaultConnection", "Data Source", @"DESKTOP-7PDSP1R\SQLEXPRESS");

            webConfig.RegisterAll();
        }
    }
}