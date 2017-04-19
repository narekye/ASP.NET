using System.Data.Entity;
using System.Web.Mvc;
using Full_REST.BookDb;

namespace Full_REST.Controllers
{
    public class HomeController : Controller
    {
        private static BooksEntities db = new BooksEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Books()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ShowAllBooks()
        {
            var books = db.Books;
            return View(books);
        }
    }
}
