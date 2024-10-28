using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class TourEmployeeConfiguration : IEntityTypeConfiguration<TourEmployee>
    {
        public void Configure(EntityTypeBuilder<TourEmployee> builder)
        {
            builder.ToTable("TourEmployees");
            
            builder.HasKey(u=>u.tourEmployeeId);
            
            builder.Property(u=>u.employeeId)
                .IsRequired();

            builder.Property(u => u.tourId)
                .IsRequired();
        }
    }
}
