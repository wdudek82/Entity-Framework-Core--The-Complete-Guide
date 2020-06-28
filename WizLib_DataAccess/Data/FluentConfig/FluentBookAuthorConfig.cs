using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentBookAuthor> builder)
        {
            builder.HasKey(ba => new {ba.Author_Id, ba.Book_Id});
            builder.HasOne(ba => ba.FluentBook)
                .WithMany(ba => ba.FluentBookAuthors)
                .HasForeignKey(ba => ba.Book_Id);
            builder.HasOne(ba => ba.FluentAuthor)
                .WithMany(ba => ba.FluentBookAuthors)
                .HasForeignKey(ba => ba.Author_Id);
        }
    }
}
