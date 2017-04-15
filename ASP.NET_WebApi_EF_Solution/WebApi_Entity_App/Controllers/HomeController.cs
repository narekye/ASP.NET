using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using WebApi_Entity_App.Database;

namespace WebApi_Entity_App.Controllers
{
    public class HomeController :
        Controller
    {
        private PlayersContext db = new PlayersContext();

        [System.Web.Http.HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
