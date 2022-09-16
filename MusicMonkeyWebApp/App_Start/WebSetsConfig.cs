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
            
            webConfig.RegisterAll();
        }
    }
}