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
            var model = new HeaderViewModel {
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
                    new HeaderLink { Action = "Register", Title = "Register", Url = "/Account/Register" },
                    new HeaderLink { Action = "Log In", Title = "Log In", Url = "/Account/Login" }
                }
            };

            model.Links.ForEach(l => l.IsActive = l.Action == model.CurrentAction);
            
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

        [Authorize(Roles = "Admin, Silver")]
        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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