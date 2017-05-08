using DesafioMundiPagg.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mappings.Entities
{
    class ContatoMapping : IEntityMappingConfiguration<Contato>
    {
        public void Map(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(p => p.ContatoId);

            builder.Property(p => p.Valor).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Tipo).IsRequired().HasMaxLength(10);
            builder.HasOne(c => c.Pessoa).WithMany(p => p.Contatos);
        }
    }
}
