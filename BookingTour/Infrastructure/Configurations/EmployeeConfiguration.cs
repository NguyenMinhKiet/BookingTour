using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(u => u.employee_id);

            builder.Property(u => u.first_name)
                .IsRequired();

            builder.Property(u => u.last_name)
                .IsRequired();

            builder.Property(u => u.email)
                .IsRequired();

            builder.Property(u => u.address)
                .IsRequired();

            builder.Property(u => u.phone)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.position)
                .IsRequired();

            builder.Property(u => u.address);
        }
    }
}
