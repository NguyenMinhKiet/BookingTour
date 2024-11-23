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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.HasKey(x=>x.HotelID);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StarRating).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x=>x.City).IsRequired();
            builder.Property(x=>x.District).IsRequired();
            builder.Property(x=>x.Ward).IsRequired();
        }
    }
}
