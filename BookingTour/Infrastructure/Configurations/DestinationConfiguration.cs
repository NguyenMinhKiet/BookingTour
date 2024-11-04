using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destinations");

            builder.HasKey(u => u.destination_id);
            builder.Property(u => u.destination_name)
                .IsRequired();
            builder.Property(u=>u.country)
                .IsRequired();
            builder.Property(u => u.city)
                .IsRequired();

        }
    }
}
