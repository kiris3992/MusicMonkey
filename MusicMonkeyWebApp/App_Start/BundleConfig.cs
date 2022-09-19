using System.Web;
using System.Web.Optimization;

namespace MusicMonkeyWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeJs_Header").Include(
                      "~/Content/Assets/js/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeJs_BodyEnd").Include(
                      "~/Content/Assets/js/bootstrap.min.js",
                      "~/Content/Assets/js/jquery.magnific-popup.min.js",
                      "~/Content/Assets/js/jquery.nicescroll.min.js",
                      "~/Content/Assets/js/jquery.barfiller.js",
                      "~/Content/Assets/js/jquery.countdown.min.js",
                      "~/Content/Assets/js/jquery.slicknav.js",
                      "~/Content/Assets/js/owl.carousel.min.js",
                      "~/Content/Assets/js/main.js",
                      "~/Content/Assets/js/jquery.jplayer.min.js",
                      "~/Content/Assets/js/jplayerInit.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/homeCss").Include(
                      "~/Content/Assets/css/bootstrap.min.css",
                      "~/Content/Assets/css/font-awesome.min.css",
                      "~/Content/Assets/css/barfiller.css",
                      "~/Content/Assets/css/nowfont.css",
                      "~/Content/Assets/css/rockville.css",
                      "~/Content/Assets/css/magnific-popup.css",
                      "~/Content/Assets/css/owl.carousel.min.css",
                      "~/Content/Assets/css/slicknav.min.css",
                      "~/Content/Assets/css/style.css"));


            bundles.Add(new StyleBundle("~/bundles/adminCss").Include(
                "~/Areas/Admin/Assets_Admin/css/bootstrap-reboot.min.css",
                "~/Areas/Admin/Assets_Admin/css/bootstrap-grid.min.css",
                "~/Areas/Admin/Assets_Admin/css/magnific-popup.css",
                "~/Areas/Admin/Assets_Admin/css/select2.min.css",
                "~/Areas/Admin/Assets_Admin/css/adminKiriakos.css"));


            bundles.Add(new ScriptBundle("~/bundles/adminJs").Include(
               "~/Areas/Admin/Assets_Admin/js/jquery-3.5.1.min.js",
                "~/Areas/Admin/Assets_Admin/js/bootstrap.bundle.min.js",
                "~/Areas/Admin/Assets_Admin/js/jquery.magnific-popup.min.js",
                "~/Areas/Admin/Assets_Admin/js/smooth-scrollbar.js",
                "~/Areas/Admin/Assets_Admin/js/smooth-scrollbar.js"));
        }
    }
}
