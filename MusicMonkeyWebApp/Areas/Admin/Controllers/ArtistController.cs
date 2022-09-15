using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMonkeyWebApp.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Admin/Artist
        public ActionResult Index()
        {
            return View();
        }


    }
}