using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace Entity_Framework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var result = GetAllData().Result;
            Console.WriteLine("All Data.. ");
            foreach (Book book in result)
                Console.WriteLine($"{book.Author}\t{book.Name}\t{book.PublishDate}");
            var idbook = GetBookById(4).Result;
            Console.WriteLine($"{idbook.Author}\t{idbook.Name}\t{idbook.PublishDate}");
        }

        public static async Task<List<Book>> GetAllData()
        {
            List<Book> result = new List<Book>();
            using (BooksEntities db = new BooksEntities())
            {
                try
                {
                    result = await db.Books.ToListAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            return result;
        }

        public static async Task<Book> GetBookById(int? id)
        {
            if (!id.HasValue) return null;
            Book book = new Book();
            using (BooksEntities db = new BooksEntities())
            {
                try
                {
                    book = await db.Books.FindAsync(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return book;
        }
    }
}