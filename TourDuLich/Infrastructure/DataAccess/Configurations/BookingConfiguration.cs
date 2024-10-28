using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(u=>u.booking_id);

            builder.Property(u => u.customer_id)
                .IsRequired();

            builder.Property(u => u.tour_id)
                .IsRequired();

            builder.Property(u => u.booking_date)
                .IsRequired();

            builder.Property(u => u.num_people)
                .IsRequired();

            builder.Property(u => u.total_price)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

        }
    }
}
