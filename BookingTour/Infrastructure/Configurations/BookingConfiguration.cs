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
        }
    }
}
