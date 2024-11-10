//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Configurations
//{
//    public class AuthorizedConfiguration : IEntityTypeConfiguration<Authorized>
//    {
//        public void Configure(EntityTypeBuilder<Authorized> builder)
//        {
//            builder.ToTable("Authorizeds");
//            builder.HasKey(u => new { u.AccountID, u.RoleID });

//            builder.Property(i=>i.RoleID)
//                .IsRequired();

//            builder.HasOne(a => a.Account)
//                .WithMany(r => r.AuthorizedRoles)
//                .HasForeignKey(a => a.AccountID)
//                .OnDelete(DeleteBehavior.Cascade);

//            builder.HasOne(r=>r.Roles)
//                .WithMany(a=>a.AuthorizedAccounts)
//                .HasForeignKey(k=>k.RoleID)
//                .OnDelete(DeleteBehavior.Cascade);
                 
//        }
//    }
//}
