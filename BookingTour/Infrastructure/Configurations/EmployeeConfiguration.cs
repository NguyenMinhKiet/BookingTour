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

            builder.HasKey(u => u.EmployeeID);

            builder.Property(u => u.FirstName)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Address)
                .IsRequired();

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.Position)
                .IsRequired();

            builder.Property(u=> u.AccountID)
                .IsRequired();

            builder.HasOne(i => i.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Employee>(u => u.AccountID)
                .OnDelete(DeleteBehavior.Cascade);
           

        }
    }
}
