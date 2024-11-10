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
    public class AuthorizedConfiguration : IEntityTypeConfiguration<Authorized>
    {
        public void Configure(EntityTypeBuilder<Authorized> builder)
        {
            builder.ToTable("Authorizeds");
            builder.HasKey(a=>a.Id);
            builder.Property(a => a.AccountID)
                .IsRequired();

            builder.Property(a => a.GroupID)
                .IsRequired();
            builder.HasIndex(i => new { i.AccountID, i.GroupID })
                .IsUnique();

            builder.HasOne(a => a.Account)
                .WithOne()
                .HasForeignKey<Authorized>(i => i.AccountID);

            builder.HasOne(r => r.RoleGroup)
                .WithOne()
                .HasForeignKey<Authorized>(i => i.GroupID);

        }
    }
}
