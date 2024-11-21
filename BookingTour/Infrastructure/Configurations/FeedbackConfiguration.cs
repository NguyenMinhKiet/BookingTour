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



            builder.HasOne(t => t.Tour)
                .WithMany(f => f.FeedBacks)
                .HasForeignKey(t => t.TourID)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ giữa Feedback và Customer
            builder.HasOne(f => f.Customer)
                .WithMany(a=>a.Feedbacks) // Customer có nhiều Feedback
                .HasForeignKey(f => f.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
