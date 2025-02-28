using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);

            builder.Property(u => u.Title);
            builder.Property(u => u.Price);
            builder.Property(u => u.Description);
            builder.Property(u => u.Category);
            builder.Property(u => u.Image);
            builder.Property(u => u.Rate);
            builder.Property(u => u.Count);

        }
    }
}
