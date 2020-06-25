using Microsoft.EntityFrameworkCore;
using WizLib_Models.Models;

namespace WizLib_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we configure Fluent API

            // composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new {ba.Author_Id, ba.Book_Id});
        }
    }
}
