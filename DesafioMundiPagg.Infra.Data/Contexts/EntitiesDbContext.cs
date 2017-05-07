using DesafioMundiPagg.Domain.Entities;
using DesafioMundiPagg.Infra.Data.Mappings;
using DesafioMundiPagg.Infra.Data.Mappings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Contexts
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .RegisterEntityMapping<Item, ItemMapping>();
        }
    
    }
}
