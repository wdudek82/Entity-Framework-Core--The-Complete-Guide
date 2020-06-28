using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> builder)
        {
            builder.HasKey(b => b.Book_Id);

            builder.Property(b => b.Title)
                .IsRequired();
            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(b => b.Price)
                .IsRequired();

            builder.HasOne(b => b.FluentBookDetail)
                .WithOne(bd => bd.FluentBook)
                // .HasForeignKey<FluentBook>("BookDetail_Id");
                .HasForeignKey<FluentBook>(b => b.BookDetail_Id);
            // one to many relation between book and publisher
            builder.HasOne(b => b.FluentPublisher)
                .WithMany(p => p.FluentBooks)
                .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
