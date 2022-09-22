using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMonkeyWebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TrackController : Controller
    {
        // GET: Admin/Track
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}