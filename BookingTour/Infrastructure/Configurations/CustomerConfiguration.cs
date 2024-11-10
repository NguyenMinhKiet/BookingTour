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

            builder.HasKey(u=>u.CustomerID);

            builder.Property(u => u.FirstName)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();
               
            builder.Property(u => u.Address)
                .IsRequired();

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(10);

            // Cấu hình mối quan hệ một-nhiều giữa Customer và Booking
            builder.HasMany(c => c.Bookings) // Customer có nhiều Booking
                .WithOne(b => b.Customer)   // Mỗi Booking thuộc về một Customer
                .HasForeignKey(b => b.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);// Đặt khóa ngoại

            builder.HasOne(i => i.Account)
                .WithOne(a => a.Customer)
                .HasForeignKey<Customer>(u => u.AccountID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
