using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class TourDestinationConfiguration : IEntityTypeConfiguration<TourDestination>
    {
        public void Configure(EntityTypeBuilder<TourDestination> builder)
        {
            builder.ToTable("TourDestinations");

            builder.HasKey(u=>u.tourDestination_id);

            builder.Property(u=>u.tour_id)
                .IsRequired();

            builder.Property(u=>u.visit_date)
                .IsRequired();

            builder.Property(u=>u.destination_id)
                .IsRequired();
        }
    }
}
