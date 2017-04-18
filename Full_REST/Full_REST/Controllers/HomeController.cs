using System.Web.Mvc;

namespace Full_REST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Books()
        {
            return View();
        }
    }
}
