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

            builder.HasKey(u=>u.feedback_id);

            builder.Property(u => u.customer_id)
                .IsRequired();

            builder.Property(u=>u.tour_id)
                .IsRequired();

            builder.Property(u => u.comments)
                .IsRequired();

            builder.Property(u => u.rating)
                .IsRequired();
        }
    }
}
