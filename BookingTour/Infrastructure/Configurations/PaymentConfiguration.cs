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

            builder.HasKey(u=>u.payment_id);

            builder.Property(u => u.payment_method)
                .IsRequired();

            builder.Property(u=>u.payment_date)
                .IsRequired();

            builder.Property(u => u.payment_method)
                .IsRequired();
        }
    }
}
