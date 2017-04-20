namespace Full_REST.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using BookDb;
    using System.Linq;
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
            if (ReferenceEquals(author, null)) return NotFound();
            var books = (from book in db.Books
                         where book.Author == author
                         select book);
            return Ok(books);
        }
        // POST api/books/add
        [Route("api/books/add")]
        public IHttpActionResult PostBooks([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest("Verify info..!!");
            var list = db.Books.ToList();
            book.BookId = list.Count;
            db.Books.Add(book);
            db.SaveChangesAsync();
            return Ok("Successfuly added to database..!!");
        }
        // PUT api/books/{id}
        public IHttpActionResult PutBookById(int id, [FromBody]Book book)
        {
            var replace = db.Books.FindAsync(id).Result;
            if (ReferenceEquals(replace, null)) return NotFound();
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
            return Ok("Completed successfully..");
        }
    }
}
