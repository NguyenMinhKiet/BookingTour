using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u=>u.customer_id);

            builder.Property(u => u.first_name)
                .IsRequired();

            builder.Property(u => u.last_name)
                .IsRequired();

            builder.Property(u => u.email)
                .IsRequired();
               
            builder.Property(u => u.address)
                .IsRequired();

            builder.Property(u => u.phone)
                .IsRequired()
                .HasMaxLength(10);

            // Cấu hình mối quan hệ một-nhiều giữa Customer và Booking
            builder.HasMany(c => c.Bookings) // Customer có nhiều Booking
                .WithOne(b => b.Customer)   // Mỗi Booking thuộc về một Customer
                .HasForeignKey(b => b.customer_id); // Đặt khóa ngoại
        }
    }
}
