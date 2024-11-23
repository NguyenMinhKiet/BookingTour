using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.DataAccess.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.ToTable("Tours", t =>
            {
                t.HasCheckConstraint("CK_Tour_EndDate_StartDate", "[EndDate] >= [StartDate]");
                t.HasCheckConstraint("CK_price", "[Price] >= 0");
            });

            builder.HasKey(u => u.TourID);

            builder.Property(u => u.Title)
                .IsRequired();

            builder.Property(u=>u.Description)
                .IsRequired();

            builder.Property(u => u.Price)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

            builder.Property(u => u.StartDate)
                .IsRequired();

            builder.Property(u => u.EndDate)
                .IsRequired();

            builder.Property(u=>u.AvailableSeats)
                .IsRequired();
            builder.Property(i => i.Category)
                .IsRequired();

        }
    }
}
