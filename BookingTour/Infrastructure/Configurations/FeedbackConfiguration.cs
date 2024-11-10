using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(u=>u.FeedbackID);
                
            builder.Property(u => u.CustomerID)
                .IsRequired();

            builder.Property(u=>u.TourID)
                .IsRequired();

            builder.Property(u => u.Comments)
                .IsRequired();

            builder.Property(u => u.Rating)
                .IsRequired();

            builder.HasOne(t=>t.Tour)
                .WithMany(f=>f.FeedBacks)
                .HasForeignKey(t=>t.TourID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
