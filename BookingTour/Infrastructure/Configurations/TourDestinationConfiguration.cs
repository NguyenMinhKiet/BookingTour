using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.DataAccess.Configurations
{
    public class TourDestinationConfiguration : IEntityTypeConfiguration<TourDestination>
    {
        public void Configure(EntityTypeBuilder<TourDestination> builder)
        {
            builder.ToTable("TourDestinations");

            builder.HasKey(u=> new {u.TourID, u.DestinationID});

            builder.Property(u=>u.VisitDate)
                .IsRequired();

            builder.HasOne(td => td.Tour) 
                .WithMany(td => td.TourDestinations)
                .HasForeignKey(td => td.TourID);

            builder.HasOne(td => td.Destination)
                .WithMany(td => td.TourDestinations)
                .HasForeignKey(td => td.DestinationID);

        }
    }
}
