using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleNumber).IsRequired().HasMaxLength(50);
        builder.Property(u => u.SaleDate).IsRequired();
        builder.Property(u => u.CustomerId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.TotalSaleAmount).IsRequired().HasColumnType("Decimal(18,2)");
        builder.Property(u => u.BranchId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.Cancelled).IsRequired().HasColumnType("bool");

        builder.HasIndex(u => u.SaleNumber);
    }
}
