using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id);

            builder.Property(u => u.Email);
            builder.Property(u => u.Username);
            builder.Property(u => u.Password);
            builder.Property(u => u.Firstname);
            builder.Property(u => u.Lastname);
            builder.Property(u => u.City);
            builder.Property(u => u.Street);
            builder.Property(u => u.Number);
            builder.Property(u => u.Zipcode);
            builder.Property(u => u.Phone);
            builder.Property(u => u.Status);
            builder.Property(u => u.Role);
            builder.Property(u => u.Lat);
            builder.Property(u => u.Long);

        }
    }
}