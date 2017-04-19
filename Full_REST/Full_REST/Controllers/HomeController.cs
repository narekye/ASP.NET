using System;
using System.Linq;
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

        [HttpGet]
        public ActionResult EditBook()
        {
            return View();
        }
        [HttpPost]
        public void EditBookById(Book book)
        {
            if (!ModelState.IsValid) return;
            var fbook = db.Books.FirstOrDefault(m => m.BookId == book.BookId);
            if (fbook == null) throw new ArgumentNullException(nameof(fbook));
            db.Entry(fbook).CurrentValues.SetValues(book);
            db.SaveChangesAsync();
            Response.Write("Succesfully data updated....");
        }
    }
}
