using ElasticsearchCRUD;
using ElasticsearchCRUD.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DesafioMundiPagg.Infra.Data.Mapping
{
    public abstract class ElasticSearchMappingBase : ElasticsearchMapping
    {
        public override string GetDocumentType(Type type)
        {
            return type.Name.ToLower();
        }

        public abstract override string GetIndexForType(Type type);

    }
}
