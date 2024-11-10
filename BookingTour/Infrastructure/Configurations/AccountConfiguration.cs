using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(i=>i.Id);

            builder.Property(i=>i.UserName)
                .IsRequired();

            builder.Property(i => i.PasswordHash)
                .IsRequired();

            builder.Property(i => i.Email)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(i => i.Customer)
                .WithOne(i => i.Account)
                .HasForeignKey<Customer>(i => i.AccountID)
                .OnDelete(DeleteBehavior.Cascade);            

        }
    }
}
