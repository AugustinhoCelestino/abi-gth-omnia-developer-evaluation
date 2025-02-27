using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.Quantity).IsRequired().HasColumnType("Decimal(18,2)");
        builder.Property(u => u.Discount).IsRequired().HasColumnType("Decimal(18,2)");
        builder.Property(u => u.TotalAmount).IsRequired().HasColumnType("Decimal(18,2)");

    }
}
