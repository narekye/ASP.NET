namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Controllers
{
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
