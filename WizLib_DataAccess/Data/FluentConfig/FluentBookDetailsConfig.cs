using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookDetailsConfig : IEntityTypeConfiguration<FluentBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentBookDetail> builder)
        {
            // FluentBookDetails
            builder.HasKey(b => b.BookDetail_Id);
            builder.Property(b => b.NumberOfChapters)
                .IsRequired();
            builder.Property(b => b.NumberOfPages);
            builder.Property(b => b.Weight);
        }
    }
}
