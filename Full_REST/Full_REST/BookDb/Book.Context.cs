namespace Full_REST.BookDb
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BooksEntities : DbContext
    {
        public BooksEntities()
            : base("name=BooksEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
    }
}
