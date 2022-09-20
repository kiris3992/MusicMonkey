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
                            new HeaderLink { Title = "Artists", Url = ""},
                            new HeaderLink { Action = "Album", Title = "Albums", Url = "/Home/Album"},
                            new HeaderLink { Title = "Tracks", Url = ""},
                        }
                    },
                    new HeaderLink { Action = "Tour", Title = "Tour", Url = "" },
                    new HeaderLink { Action = "Plans", Title = "Pricing Plans", Url = "" },
                    
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

        [Authorize(Roles = "Admin, Gold")]
        public ActionResult Album()
        {
            return View();
        }
    }
}