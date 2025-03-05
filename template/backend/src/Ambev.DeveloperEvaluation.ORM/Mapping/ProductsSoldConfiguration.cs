using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductsSoldConfiguration : IEntityTypeConfiguration<ProductsSold>
    {
        public void Configure(EntityTypeBuilder<ProductsSold> builder)
        {
            builder.ToTable("ProductsSolds");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);

            builder.Property(u => u.ProductId);
            builder.Property(u => u.SaleId);
            builder.Property(u => u.Quantity);
            builder.Property(u => u.UnitPrice);
            builder.Property(u => u.Discont);
            builder.Property(u => u.TotalAmount);
        }
    }
}
