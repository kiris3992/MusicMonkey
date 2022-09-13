using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicMonkeyWebApp.Helpers;

namespace MusicMonkeyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HeaderViewModel CreateHeader()
        {
            var model = new HeaderViewModel
            {
                CurrentAction = Request.RequestContext.RouteData.Values["action"].ToString(),
                Links = new List<HeaderLink> {
                    new HeaderLink { Action = "Index", Title = "Home", Url = "/" },
                    new HeaderLink { Action = "About", Title = "About", Url = "/Home/About" },
                    new HeaderLink { Action = "Music", Title = "Music", Url = "",
                        SubLinks = new List<HeaderLink> {
                            new HeaderLink { Title = "Artists", Url = "" },
                            new HeaderLink { Action = "Album", Title = "Albums", Url = "/Home/Album" },
                            new HeaderLink { Title = "Tracks", Url = "", },
                        }
                    },
                    new HeaderLink { Action = "Plans", Title = "Pricing Plans", Url = "" },
                    new HeaderLink { Action = "Contact", Title = "Contact", Url = "/Home/Contact" },
                }
            };

            foreach (var link in model.Links)
            {
                link.IsActive = link.Action == model.CurrentAction;
                if (link.SubLinks != null)
                {
                    foreach (var subLink in link.SubLinks) if (subLink.Action == model.CurrentAction) subLink.IsActive = link.IsActive = true;
                }
            }

            return model;
        }

        [ChildActionOnly]
        public PartialViewResult Header() => PartialView("Master/_Partial_Header", CreateHeader());
        [ChildActionOnly]
        public PartialViewResult Footer() => PartialView("Master/_Partial_Footer", CreateHeader());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Album()
        {
            return View();
        }
    }
}