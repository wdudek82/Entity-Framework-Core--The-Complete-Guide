using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.Data.FluentConfig;
using WizLib_Models.Models;

namespace WizLib_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookDetailsFromView> BookDetailsFromViews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
        public DbSet<FluentBook> FluentBooks { get; set; }
        public DbSet<FluentAuthor> FluentAuthors { get; set; }
        public DbSet<FluentPublisher> FluentPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we configure Fluent API

            // category table and column names
            modelBuilder.Entity<Category>()
                .ToTable("tbl_Category");
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnName("CategoryName");

            // composite key
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new {ba.Author_Id, ba.Book_Id});

            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailsConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<BookDetailsFromView>()
                .HasNoKey()
                .ToView("GetOnlyBookDetails");
        }
    }
}
