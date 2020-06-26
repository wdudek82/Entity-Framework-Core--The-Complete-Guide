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
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we configure Fluent API

            // composite key
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new {ba.Author_Id, ba.Book_Id});

            // BookDetails
            modelBuilder.Entity<FluentBookDetail>()
                .HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.NumberOfChapters)
                .IsRequired();
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.NumberOfPages);
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.Weight);

            // modelBuilder.Entity<FluentBook>()
            //     .Property(b => b.Title)
            //     .IsRequired();
            // modelBuilder.Entity<FluentBook>()
            //     .Property(b => b.ISBN)
            //     .IsRequired()
            //     .HasMaxLength(15);
            // modelBuilder.Entity<FluentBook>()
            //     .Property(b => b.Price)
            //     .IsRequired();
            // modelBuilder.Entity<FluentBook>()
            //     .HasKey(c => c.Book_Id);
        }
    }
}
