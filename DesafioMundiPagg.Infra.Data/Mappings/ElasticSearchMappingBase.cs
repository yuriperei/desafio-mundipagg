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

        public override void MapEntityValues(EntityContextInfo entityInfo, ElasticsearchCrudJsonWriter elasticsearchCrudJsonWriter, bool beginMappingTree = false, bool createPropertyMappings = false)
        {
            var propertyInfo = entityInfo.Document.GetType().GetProperties();
            foreach (var prop in propertyInfo)
            {
                MapValue(prop.Name, prop.GetValue(entityInfo.Document), elasticsearchCrudJsonWriter.JsonWriter);
            }

        }

        public override string GetDocumentType(Type type)
        {
            return type.Name.ToLower();
        }

        public abstract override string GetIndexForType(Type type);

    }
}
