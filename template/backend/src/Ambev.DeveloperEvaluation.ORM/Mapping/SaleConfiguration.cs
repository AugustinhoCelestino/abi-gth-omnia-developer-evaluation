using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);

            builder.Property(u => u.CartId);
            builder.Property(u => u.Date);
            builder.Property(u => u.Customer);
            builder.Property(u => u.Branch);
            builder.Property(u => u.Cancelled);
        }
    }
}
