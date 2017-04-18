using System.Linq;
using System.Net;
using System.Web.Routing;

namespace Full_REST.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using BookDb;
    // CRUD interface
    public class BooksController : ApiController
    {
        private BooksEntities db = new BooksEntities();
        // GET api/books
        // This method used in MVC view with AJAX
        public IEnumerable<Book> GetAllBooks()
        {
            var result = db.Books;
            return result;
        }
        // GET api/book/{id}
        public IHttpActionResult GetBookById(int id)
        {
            var book = db.Books.FindAsync(id).Result;
            if (book != null) return Ok(book);
            return BadRequest("No matches..!!");
        }
        // GET api/books/{author}
        [Route("api/books/search/{author}")]
        public IHttpActionResult GetBooksByAuthor(string author)
        {
            var sbook = (from book in db.Books
                where book.Author == author
                select book);

            if (sbook == null)
                return BadRequest("No such author detected..!!");
            return Ok(sbook);
        }
        // POST api/books/add
        [Route("api/books/add")]
        public IHttpActionResult PostBooks([FromBody] Book book)
        {
            var list = db.Books.ToList();
            var id = list.Count;
            book.BookId = id;
            if (!ModelState.IsValid) return BadRequest("Verify info.....!!");
            db.Books.Add(book);
            db.SaveChangesAsync();
            return Ok("Successfuly added to database...!!"); 
        }
        // PUT api/books/{id}
        public IHttpActionResult PutBookById(int id, [FromBody]Book book)
        {
            var replace = db.Books.FindAsync(id).Result;
            if(ReferenceEquals(replace,null)) return NotFound();
            replace.Name = book.Name;
            replace.Author = book.Author;
            replace.PublishDate = book.PublishDate;
            db.SaveChangesAsync();
            return Ok("Successfully modified..");
        }
        // DELETE api/books/{id}
        public IHttpActionResult DeleteBookById(int id)
        {
            var book = db.Books.FindAsync(id).Result;
            if (ReferenceEquals(book, null)) return NotFound();
            db.Books.Remove(book);
            db.SaveChangesAsync();
            return Ok("Completed successfuly..");
        }
    }
}
