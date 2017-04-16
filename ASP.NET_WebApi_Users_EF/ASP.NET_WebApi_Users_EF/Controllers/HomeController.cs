using System.Web.Mvc;

namespace ASP.NET_WebApi_Users_EF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
