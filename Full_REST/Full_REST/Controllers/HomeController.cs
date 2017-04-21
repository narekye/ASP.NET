
namespace Full_REST.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using BookDb;
    using System.Threading;

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
            Response.Write("Succesfully updated data....");
        }

        [HttpGet]
        public ActionResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public void AddBook(Book book)
        {
            var count = db.Books.Count();
            book.BookId = count + 1;
            db.Books.Add(book);
            db.SaveChangesAsync();  
            Response.Write("Succesfully added to database...");
        }

        [HttpGet]
        public void DeleteById(int id)
        {
            Response.Write("You selected id " + id + "?");
            var book = (from b in db.Books
                where b.BookId == id
                select b).FirstOrDefault();
            if (ReferenceEquals(book, null)) return;
            Thread.Sleep(1000);
            db.Books.Remove(book);
            db.SaveChangesAsync();
        }
    }
}
