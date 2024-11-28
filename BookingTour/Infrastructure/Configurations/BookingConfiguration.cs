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
            builder.Property(u => u.PaymentID)
                .IsRequired(false);
            builder.Property(u => u.TotalPrice)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.Customer)    
                   .WithMany(b => b.Bookings)     
                   .HasForeignKey(b => b.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Tour)
                   .WithMany(t => t.Bookings) 
                   .HasForeignKey(b => b.TourID) 
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
