using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace MusicMonkeyWebApp.Areas.Admin.Controllers
{
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

        [HttpPost]
        public object FormData(FormCollection form,  HttpPostedFileBase data_song)
        {
            bool success = true;

            string title = form["data-title"];
            success = int.TryParse(form["data-sel-artist"], out int artistId);
            success = int.TryParse(form["data-sel-album"], out int albumId);
            success = int.TryParse(form["data-input-popularity"], out int popularity);
            success = int.TryParse(form["data-input-mins"], out int minutes);
            success = int.TryParse(form["data-input-secs"], out int seconds);

            int[] genres = form["data-sel-genres"] == null ? null : form["data-sel-genres"].Split(',').Select(o => int.Parse(o)).ToArray();

            return new { success };
        }
    }
}