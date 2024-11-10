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

            builder.Property(u => u.Method)
                .IsRequired();

            builder.Property(u=>u.CreateAt)
                .IsRequired();

            builder.HasOne(i => i.Booking)
                .WithOne(i => i.Payment)
                .HasForeignKey<Payment>(i => i.BookingID);
                
                
                
        }
    }
}
