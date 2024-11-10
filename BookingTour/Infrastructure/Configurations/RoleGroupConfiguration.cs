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
    public class RoleGroupConfiguration : IEntityTypeConfiguration<RoleGroup>
    {
        public void Configure(EntityTypeBuilder<RoleGroup> builder)
        {
            builder.ToTable("RoleGroups");

            builder.HasKey(i => i.GroupID);

            builder.Property(i => i.Name)
                .IsRequired();

            builder.Property(i => i.RoleID)
                .IsRequired();

            builder.HasMany(i => i.Roles)
                .WithOne(i => i.RoleGroup)
                .HasForeignKey(i => i.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
