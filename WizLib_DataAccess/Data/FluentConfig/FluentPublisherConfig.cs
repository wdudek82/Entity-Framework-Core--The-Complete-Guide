using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
    {
        public void Configure(EntityTypeBuilder<FluentPublisher> builder)
        {
            builder.HasKey(p => p.Publisher_Id);
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Location)
                .IsRequired();
        }
    }
}
