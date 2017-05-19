using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
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
            Console.WriteLine("By Id -> 1");
            Book idbook = GetById(1).Result;
            Console.WriteLine($"{idbook.Author}\t{idbook.Name}\t{idbook.PublishDate}");
            DeleteById(21).Wait();
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

        public static async Task<Book> GetById(int? id)
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

        public static async Task DeleteById(int? id)
        {
            if (!id.HasValue) return;
            await Task.Run(() =>
            {
                using (BooksEntities db = new BooksEntities())
                {
                    bool flag = false;
                    try
                    {
                        Book book = db.Books.FirstOrDefault(p => p.BookId == id);
                        if (book != null)
                        {
                            db.Books.Remove(book);
                            int count = db.SaveChangesAsync().Result;
                            Console.WriteLine($"affecred count {count}");
                            flag = true;
                        }
                        flag = false;
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine(flag ? "Succeded.." : "Failed..");
                    }
                }
            });
        }
    }
}