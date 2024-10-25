using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(u=>u.payment_id);

            builder.Property(u => u.payment_method)
                .IsRequired();

            builder.Property(u=>u.payment_date)
                .IsRequired();

            builder.Property(u => u.payment_method)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
