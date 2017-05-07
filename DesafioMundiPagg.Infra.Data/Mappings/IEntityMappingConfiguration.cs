using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mappings
{
    public interface IEntityMappingConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
