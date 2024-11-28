using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(u=>u.PaymentID);
            builder.Property(u => u.BookingID)
                .IsRequired();
            builder.Property(i=>i.Total)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.Booking)
                .WithOne(i => i.Payment)
                .HasForeignKey<Payment>(i => i.BookingID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Customer)
                .WithMany(i=>i.Payments)
                .HasForeignKey(i => i.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
