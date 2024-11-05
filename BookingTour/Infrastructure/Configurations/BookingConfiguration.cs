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
                t=> t.HasCheckConstraint("CK_Booking_NumPeople", "[num_people] >= 0"));

            builder.HasKey(u=>u.booking_id);

            builder.Property(u => u.customer_id)
                .IsRequired();

            builder.Property(u => u.tour_id)
                .IsRequired();

            builder.Property(u => u.booking_date)
                .IsRequired();

            builder.Property(u => u.num_people)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.total_price)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.Customer)    // Mỗi Booking thuộc về một Customer
                   .WithMany(b => b.Bookings)      // Customer có nhiều Booking
                   .HasForeignKey(b => b.customer_id); // Đặt khóa ngoại

            builder.HasMany(b => b.Payments)
                .WithOne(p=>p.Booking)
                .HasForeignKey(fk=>fk.booking_id);

            builder.HasOne(b => b.Customer)
                   .WithMany() // Nếu Customer có nhiều Booking, không cần khai báo danh sách Booking ở Customer
                   .HasForeignKey(b => b.customer_id)
                   .OnDelete(DeleteBehavior.Cascade); // Xoá Booking khi Customer bị xóa

            // Thiết lập quan hệ N-1 với Tour
            builder.HasOne(b => b.Tour) // Booking có 1 Tour
                   .WithMany(t => t.Bookings) // Tour có nhiều Booking
                   .HasForeignKey(b => b.tour_id) // Khóa ngoại
                   .OnDelete(DeleteBehavior.Cascade); // Hành động xóa (tuỳ chọn)
        }
    }
}
