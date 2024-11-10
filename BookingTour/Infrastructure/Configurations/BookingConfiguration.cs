using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings", 
                t=>
                {
                    t.HasCheckConstraint("CK_Booking_Adult", "[Adult] >= 0");
                    t.HasCheckConstraint("CK_Booking_Child", "[Child] >= 0");
                });

            builder.HasKey(u=>u.BookingID);

            builder.Property(u => u.CustomerID)
                .IsRequired();

            builder.Property(u => u.TourID)
                .IsRequired();

            builder.Property(u => u.CreateAt)
                .IsRequired();

            builder.Property(u => u.Adult)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.Child)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.TotalPrice)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.Customer)    // Mỗi Booking thuộc về một Customer
                   .WithMany(b => b.Bookings)      // Customer có nhiều Booking
                   .HasForeignKey(b => b.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);// Đặt khóa ngoại

            builder.HasOne(b => b.Payment)
                .WithOne(p=>p.Booking)
                .HasForeignKey<Payment>(fk => fk.BookingID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Customer)
                   .WithMany() // Nếu Customer có nhiều Booking, không cần khai báo danh sách Booking ở Customer
                   .HasForeignKey(b => b.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade); // Xoá Booking khi Customer bị xóa

            // Thiết lập quan hệ N-1 với Tour
            builder.HasOne(b => b.Tour) // Booking có 1 Tour
                   .WithMany(t => t.Bookings) // Tour có nhiều Booking
                   .HasForeignKey(b => b.TourID) // Khóa ngoại
                   .OnDelete(DeleteBehavior.Cascade); // Hành động xóa (tuỳ chọn)
        }
    }
}
