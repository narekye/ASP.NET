using System.Web.Mvc;

namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // simple index view with RAZOR
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
