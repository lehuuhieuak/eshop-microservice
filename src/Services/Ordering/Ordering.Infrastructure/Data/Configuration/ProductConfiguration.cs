using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(
                customerId => customerId.Value,
                dbId => ProductId.Of(dbId));
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).IsRequired();
        }
    }
}
