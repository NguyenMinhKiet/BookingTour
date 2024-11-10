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

            builder.Property(i=>i.Username)
                .IsRequired();

            builder.Property(i => i.Password)
                .IsRequired();

            builder.Property(i => i.Phone)
                .IsRequired();

            builder.Property(i => i.Email)
                .IsRequired();

            builder.HasIndex(i => i.Phone)
                .IsUnique();
            builder.HasIndex(i => i.Email)
                .IsUnique();
        }
    }
}
