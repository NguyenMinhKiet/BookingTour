using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TourHotelConfiguartion : IEntityTypeConfiguration<TourHotel>
    {
        public void Configure(EntityTypeBuilder<TourHotel> builder)
        {
            builder.ToTable("TourHotels");

            builder.HasKey(x => new { x.TourID, x.HotelID });

            builder.HasOne(x => x.Tour)
                .WithMany(x => x.TourHotels)
                .HasForeignKey(x => x.TourID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Hotel)
                .WithMany(x => x.TourHotels)
                .HasForeignKey(x => x.HotelID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
