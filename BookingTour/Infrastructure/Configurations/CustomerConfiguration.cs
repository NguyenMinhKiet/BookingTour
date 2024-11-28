using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u=>u.CustomerID);

            builder.Property(u => u.FirstName)
                .IsRequired();

            builder.Property(u => u.LastName)
                .IsRequired();
               
            builder.Property(u => u.Address)
                .IsRequired();

            // Cấu hình mối quan hệ giữa Customer và Account
            builder.HasOne(i => i.Account)
                .WithOne()
                .HasForeignKey<Customer>(u => u.AccountID)
                .OnDelete(DeleteBehavior.Cascade); 


        }
    }
}
