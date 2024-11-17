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
           
            builder.Property(u => u.Address)
                .IsRequired();

            builder.Property(u => u.Position)
                .IsRequired();

            builder.HasOne(i => i.Account)        
                .WithOne()           
                .HasForeignKey<Employee>(i => i.AccountID)
                .OnDelete(DeleteBehavior.Cascade);  

        }
    }
}
