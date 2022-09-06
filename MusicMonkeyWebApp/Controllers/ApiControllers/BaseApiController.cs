using DAL;
using RepositoryService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MusicMonkeyWebApp.Controllers.ApiControllers
{
    public class BaseApiController : ApiController
    {
        protected ApplicationDbContext db;
        protected UnitOfWork unit;

        public BaseApiController()
        {
            db = new ApplicationDbContext();
            unit = new UnitOfWork(db);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) unit.Dispose();
            base.Dispose(disposing);
        }
    }
}