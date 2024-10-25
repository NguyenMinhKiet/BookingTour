using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u=>u.customer_id);

            builder.Property(u => u.first_name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u=>u.last_name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u=>u.email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.address)
                .IsRequired();

            builder.Property(u => u.phone)
                .IsRequired()
                .HasMaxLength(10);
                                
        }
    }
}
