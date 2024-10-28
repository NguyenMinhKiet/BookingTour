using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Infrastructure.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(u => u.employee_id);

            builder.Property(u => u.first_name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.last_name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.address)
                .IsRequired();

            builder.Property(u => u.phone)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.position)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.address)
                .HasMaxLength(255);
        }
    }
}
