using DesafioMundiPagg.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mappings
{
    public class LocalizacaoSearchMapping : ElasticSearchMappingBase
    {
        public override string GetIndexForType(Type type)
        {
            return "localizacoes";
        }
    }
}
