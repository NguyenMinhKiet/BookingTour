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

            builder.HasKey(u => u.DestinationID);
            builder.Property(u => u.Name)
                .IsRequired();
            builder.Property(u=>u.Country)
                .IsRequired();
            builder.Property(u => u.City)
                .IsRequired();

        }
    }
}
