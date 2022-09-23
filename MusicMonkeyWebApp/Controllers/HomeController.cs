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
                            new HeaderLink { Action = "Artist", Title = "Artists", Url = "/Home/Artist"},
                            new HeaderLink { Action = "Album", Title = "Albums", Url = "/Home/Album"},
                            new HeaderLink { Action = "Track", Title = "Tracks", Url = "/Home/Track"},
                        }
                    },
                    new HeaderLink { Action = "Tour", Title = "Tour", Url = "/Home/Tour" },
                    new HeaderLink { Action = "Plans", Title = "Pricing Plans", Url = "/Home/Plans" },
                    new HeaderLink { Action = "Contact", Title = "Contact", Url = "/Home/Contact" }
                    
                }
            };

            model.Links.ForEach(l => l.IsActive = l.Action == model.CurrentAction);

            var curUser = Request.RequestContext.HttpContext.User;
            model.Links = new List<HeaderLink>(model.Links.Where(o => o.Roles == null || o.Roles.Any(r => curUser.IsInRole(r))).ToList());

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

        [Authorize(Roles = "Silver, Gold, Admin")]
        public ActionResult Album()
        {
            return View();
        }
        public ActionResult Tour()
        {
            return View();
        }

        public ActionResult Plans()
        {
            return View();
        }

        public ActionResult Artist()
        {
            return View();
        }

        public ActionResult Track()
        {
            return View();
        }

        public ActionResult ChatRoom()
        {
            return View();
        }

        [Authorize(Roles = "Silver, Gold, Admin")]
        public ActionResult Charge()
        {
            return View();
        }
    }
}