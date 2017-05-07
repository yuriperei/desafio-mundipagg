using DesafioMundiPagg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mappings.Entities
{
    class ItemMapping : IEntityMappingConfiguration<Item>
    {
        public void Map(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Course");
            //builder.ToTable("User");
            //builder.HasKey(m => m.Id);
            //builder.Property(m => m.Id).HasColumnName("UserId");
            //builder.Property(m => m.FirstName).IsRequired().HasMaxLength(64);
            //builder.Property(m => m.LastName).IsRequired().HasMaxLength(64);
            //builder.Property(m => m.DateOfBirth);
            //builder.Property(m => m.MobileNumber).IsRequired(false);
        }
    }
}
