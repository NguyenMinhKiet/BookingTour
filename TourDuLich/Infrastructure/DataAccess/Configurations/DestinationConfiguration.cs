using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destinations");

            builder.HasKey(u => u.destination_id);
            builder.Property(u => u.destination_name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u=>u.country)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u=>u.city)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
