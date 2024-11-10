using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class TourEmployeeConfiguration : IEntityTypeConfiguration<TourEmployee>
    {
        public void Configure(EntityTypeBuilder<TourEmployee> builder)
        {
            builder.ToTable("TourEmployees");
            
            builder.HasKey(u=> new {u.TourID, u.EmployeeID});

            builder.HasOne(td => td.Tour)
                .WithMany(td => td.TourEmployees)
                .HasForeignKey(td => td.TourID);

            builder.HasOne(td => td.Employee)
                .WithMany(td => td.TourEmployee)
                .HasForeignKey(td => td.EmployeeID);
        }
    }
}
