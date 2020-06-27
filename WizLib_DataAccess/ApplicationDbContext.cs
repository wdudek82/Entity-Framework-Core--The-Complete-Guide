using Microsoft.EntityFrameworkCore;
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

            // FluentBookDetails
            modelBuilder.Entity<FluentBookDetail>()
                .HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.NumberOfChapters)
                .IsRequired();
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.NumberOfPages);
            modelBuilder.Entity<FluentBookDetail>()
                .Property(b => b.Weight);

            // FLuentBook
            modelBuilder.Entity<FluentBook>()
                .HasKey(b => b.Book_Id);
            modelBuilder.Entity<FluentBook>()
                .Property(b => b.Title)
                .IsRequired();
            modelBuilder.Entity<FluentBook>()
                .Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);
            modelBuilder.Entity<FluentBook>()
                .Property(b => b.Price)
                .IsRequired();

            // FluentAuthor
            modelBuilder.Entity<FluentAuthor>()
                .HasKey(a => a.Author_Id);
            modelBuilder.Entity<FluentAuthor>()
                .Property(a => a.FirstName)
                .IsRequired();
            modelBuilder.Entity<FluentAuthor>()
                .Property(a => a.LastName)
                .IsRequired();
            modelBuilder.Entity<FluentAuthor>()
                .Ignore(a => a.FullName);
            modelBuilder.Entity<FluentAuthor>()
                .Property(a => a.BirthDate);
            modelBuilder.Entity<FluentAuthor>()
                .Property(a => a.Location);

            // FluentPublisher
            modelBuilder.Entity<FluentPublisher>()
                .HasKey(p => p.Publisher_Id);
            modelBuilder.Entity<FluentPublisher>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<FluentPublisher>()
                .Property(p => p.Location)
                .IsRequired();
        }
    }
}
