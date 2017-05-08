using DesafioMundiPagg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mappings.Entities
{
    public class PessoaMapping : IEntityMappingConfiguration<Pessoa>
    {
        public void Map(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(p => p.PessoaId);

            builder.HasOne(p => p.Localizacao);


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
