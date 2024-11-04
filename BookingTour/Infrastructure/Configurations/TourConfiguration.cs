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
                t.HasCheckConstraint("CK_Tour_EndDate_StartDate", "[end_Date] >= [start_Date]");
                t.HasCheckConstraint("CK_price", "[price] >= 0");
            });

            builder.HasKey(u => u.tour_id);

            builder.Property(u => u.tour_name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u=>u.description)
                .IsRequired();

            builder.Property(u => u.price)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnType("decimal(10,2)");

            builder.Property(u => u.start_Date)
                .IsRequired();

            builder.Property(u => u.end_Date)
                .IsRequired();

            builder.HasMany(u => u.FeedBacks)
                .WithOne(u => u.Tour)
                .HasForeignKey(u => u.feedback_id);



        }
    }
}
